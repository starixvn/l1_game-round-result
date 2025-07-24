const fs = require('fs');
const path = require('path');

// Configuration
const mainAppsettingsPath = 'GameRoundResult.Web/appsettings.json';
const configsDir = 'GameRoundResult.Web/Configs';

// Parse command line arguments
const args = process.argv.slice(2);
const cultureCode = args[0];

// Parse ignore options
const ignoreOptions = [];
let i = 1;
while (i < args.length) {
  if (args[i] === '--ignore' || args[i] === '-i') {
    if (i + 1 < args.length) {
      ignoreOptions.push(args[i + 1]);
      i += 2;
    } else {
      console.error('Error: --ignore requires a pattern');
      process.exit(1);
    }
  } else if (args[i] === '--help' || args[i] === '-h') {
    showHelp();
    process.exit(0);
  } else {
    console.error(`Unknown option: ${args[i]}`);
    showHelp();
    process.exit(1);
  }
}

if (!cultureCode) {
  console.error('Error: Culture code is required');
  showHelp();
  process.exit(1);
}

function showHelp() {
  console.log('Usage: node add-culture-support-advanced.js <culture-code> [options]');
  console.log('');
  console.log('Arguments:');
  console.log('  <culture-code>    The culture code to add (e.g., ja-JP, ko-KR, fr-FR)');
  console.log('');
  console.log('Options:');
  console.log('  --ignore, -i <pattern>  Ignore files/directories matching pattern');
  console.log('  --help, -h              Show this help message');
  console.log('');
  console.log('Examples:');
  console.log('  node add-culture-support-advanced.js ja-JP');
  console.log('  node add-culture-support-advanced.js ko-KR --ignore AWSDR');
  console.log('  node add-culture-support-advanced.js fr-FR --ignore KLPROD --ignore LOCAL_2');
  console.log('  node add-culture-support-advanced.js es-ES --ignore game-history-sg');
  console.log('');
  console.log('Ignore patterns can match:');
  console.log('  - Environment names (AWSDR, KLPROD, LOCAL_2, etc.)');
  console.log('  - System directories (sc1, vg2, gn, game-history-sg, etc.)');
  console.log('  - Specific file names (appsettings.LOCAL_3.json)');
}

console.log(`Adding culture support for '${cultureCode}' to all appsettings files...`);
console.log(`Main appsettings path: ${mainAppsettingsPath}`);
console.log(`Configs directory: ${configsDir}`);
console.log(`Culture code: ${cultureCode}`);
if (ignoreOptions.length > 0) {
  console.log(`Ignore patterns: ${ignoreOptions.join(', ')}`);
}
console.log('');

function shouldIgnoreFile(filePath) {
  const fileName = path.basename(filePath);
  const dirName = path.dirname(filePath).split(path.sep).pop();

  for (const pattern of ignoreOptions) {
    // Check if pattern matches filename or directory name
    if (fileName.includes(pattern) || dirName.includes(pattern)) {
      return true;
    }
  }
  return false;
}

function updateAppsettingsFile(filePath) {
  try {
    // Check if file should be ignored
    if (shouldIgnoreFile(filePath)) {
      console.log(`  ⏭️  Skipped ${path.basename(filePath)} (ignored)`);
      return 'ignored';
    }

    // Read the appsettings file
    const appsettingsContent = fs.readFileSync(filePath, 'utf8');
    const appsettings = JSON.parse(appsettingsContent);

    // Check if culture is already in the SupportedCultures array
    if (appsettings.SupportedCultures && Array.isArray(appsettings.SupportedCultures)) {
      if (appsettings.SupportedCultures.includes(cultureCode)) {
        console.log(`  ✓ Culture '${cultureCode}' is already in ${path.basename(filePath)}`);
        return false; // No changes made
      }

      // Add culture to the array
      appsettings.SupportedCultures.push(cultureCode);

      // Sort the cultures alphabetically for consistency
      appsettings.SupportedCultures.sort();

      console.log(`  ✓ Added '${cultureCode}' to ${path.basename(filePath)}`);
      console.log(`    Updated SupportedCultures: [${appsettings.SupportedCultures.join(', ')}]`);
    } else {
      console.error(`  ✗ SupportedCultures is not found or is not an array in ${path.basename(filePath)}`);
      return false;
    }

    // Write the updated content back to the file
    const updatedContent = JSON.stringify(appsettings, null, 2);
    fs.writeFileSync(filePath, updatedContent, 'utf8');

    return true; // Changes made
  } catch (error) {
    console.error(`  ✗ Error updating ${path.basename(filePath)}: ${error.message}`);
    return false;
  }
}

function getAllAppsettingsFiles() {
  const files = [];

  // Add main appsettings.json
  if (fs.existsSync(mainAppsettingsPath)) {
    files.push(mainAppsettingsPath);
  }

  // Get all appsettings files from Configs subdirectories
  if (fs.existsSync(configsDir)) {
    const systemDirs = fs.readdirSync(configsDir, { withFileTypes: true })
      .filter(dirent => dirent.isDirectory())
      .map(dirent => dirent.name);

    for (const systemDir of systemDirs) {
      const systemPath = path.join(configsDir, systemDir);
      const envFiles = fs.readdirSync(systemPath, { withFileTypes: true })
        .filter(dirent => dirent.isFile() && dirent.name.startsWith('appsettings.') && dirent.name.endsWith('.json'))
        .map(dirent => path.join(systemPath, dirent.name));

      files.push(...envFiles);
    }
  }

  return files;
}

function updateAllAppsettings() {
  const files = getAllAppsettingsFiles();

  console.log(`Found ${files.length} appsettings files to update:`);
  files.forEach(file => {
    const status = shouldIgnoreFile(file) ? ' (ignored)' : '';
    console.log(`  - ${file}${status}`);
  });
  console.log('');

  let updatedCount = 0;
  let skippedCount = 0;
  let ignoredCount = 0;
  let errorCount = 0;

  for (const file of files) {
    const result = updateAppsettingsFile(file);
    if (result === true) {
      updatedCount++;
    } else if (result === false) {
      skippedCount++;
    } else if (result === 'ignored') {
      ignoredCount++;
    } else {
      errorCount++;
    }
  }

  console.log('');
  console.log('=== Summary ===');
  console.log(`✓ Updated: ${updatedCount} files`);
  console.log(`- Skipped (already has ${cultureCode}): ${skippedCount} files`);
  console.log(`⏭️  Ignored: ${ignoredCount} files`);
  console.log(`✗ Errors: ${errorCount} files`);
  console.log('');

  if (updatedCount > 0) {
    console.log(`✓ Successfully updated appsettings files with ${cultureCode} culture support`);
    console.log('');
    console.log('Next steps:');
    console.log(`1. Add language files for ${cultureCode} culture`);
    console.log(`2. Test the application with ${cultureCode} culture`);
    console.log('3. Deploy the updated configurations to all environments');
  } else {
    console.log(`No files were updated. ${cultureCode} culture may already be supported in all configurations.`);
  }
}

// Run the update
updateAllAppsettings(); 