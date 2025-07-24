const fs = require('fs');
const path = require('path');

// Configuration
const sourceDir = 'Game Round Result Tolgee';
const targetBaseDir = 'GameRoundResult.Web/Resources/Tolgee';
const sourceLanguage = 'ja.json';
const targetLanguage = 'ja-JP.json';
const requiredFile = 'en-US.json'; // Only copy to folders that have this file

// Report tracking
const report = {
  copied: [],
  skipped: [],
  errors: [],
  totalSourceFiles: 0,
  totalTargetFolders: 0
};

console.log('Starting Japanese language file copy process...');
console.log(`Source directory: ${sourceDir}`);
console.log(`Target base directory: ${targetBaseDir}`);
console.log(`Source language file: ${sourceLanguage}`);
console.log(`Target language file: ${targetLanguage}`);
console.log(`Required file for target folders: ${requiredFile}`);
console.log('');

// Function to copy a file
function copyFile(sourcePath, targetPath, namespace) {
  try {
    // Create target directory if it doesn't exist
    const targetDir = path.dirname(targetPath);
    if (!fs.existsSync(targetDir)) {
      fs.mkdirSync(targetDir, { recursive: true });
      console.log(`Created directory: ${targetDir}`);
    }

    // Copy the file
    fs.copyFileSync(sourcePath, targetPath);
    console.log(`✓ Copied: ${path.relative('.', sourcePath)} → ${path.relative('.', targetPath)}`);
    
    // Add to report
    report.copied.push({
      namespace: namespace,
      source: path.relative('.', sourcePath),
      target: path.relative('.', targetPath)
    });
    
    return true;
  } catch (error) {
    console.error(`✗ Error copying ${sourcePath}: ${error.message}`);
    
    // Add to report
    report.errors.push({
      namespace: namespace,
      source: path.relative('.', sourcePath),
      target: path.relative('.', targetPath),
      error: error.message
    });
    
    return false;
  }
}

// Function to check if target folder has en-US.json
function hasRequiredFile(targetDir) {
  const requiredFilePath = path.join(targetDir, requiredFile);
  return fs.existsSync(requiredFilePath);
}

// Function to process a directory
function processDirectory(dirPath) {
  try {
    const items = fs.readdirSync(dirPath);

    for (const item of items) {
      const fullPath = path.join(dirPath, item);
      const stat = fs.statSync(fullPath);

      if (stat.isDirectory()) {
        // Check if this directory contains a ja.json file
        const jaFilePath = path.join(fullPath, sourceLanguage);

        if (fs.existsSync(jaFilePath)) {
          // This is a namespace directory with Japanese translations
          const namespace = item;
          const targetDir = path.join(targetBaseDir, namespace);
          const targetFile = path.join(targetDir, targetLanguage);
          
          report.totalSourceFiles++;

          // Only copy if the target folder has en-US.json
          if (hasRequiredFile(targetDir)) {
            copyFile(jaFilePath, targetFile, namespace);
          } else {
            console.log(`⚠ Skipped: ${namespace} (no ${requiredFile} found in target folder)`);
            
            // Add to report
            report.skipped.push({
              namespace: namespace,
              source: path.relative('.', jaFilePath),
              reason: `No ${requiredFile} found in target folder`
            });
          }
        } else {
          // Recursively process subdirectories
          processDirectory(fullPath);
        }
      }
    }
  } catch (error) {
    console.error(`Error processing directory ${dirPath}: ${error.message}`);
  }
}

// Function to print detailed report
function printReport() {
  console.log('');
  console.log('='.repeat(60));
  console.log('📊 COPY OPERATION REPORT');
  console.log('='.repeat(60));
  
  console.log(`📁 Total source files found: ${report.totalSourceFiles}`);
  console.log(`✅ Successfully copied: ${report.copied.length}`);
  console.log(`⚠️  Skipped: ${report.skipped.length}`);
  console.log(`❌ Errors: ${report.errors.length}`);
  console.log('');
  
  if (report.copied.length > 0) {
    console.log('✅ SUCCESSFULLY COPIED:');
    console.log('-'.repeat(40));
    report.copied.forEach((item, index) => {
      console.log(`${index + 1}. ${item.namespace}`);
      console.log(`   Source: ${item.source}`);
      console.log(`   Target: ${item.target}`);
      console.log('');
    });
  }
  
  if (report.skipped.length > 0) {
    console.log('⚠️  SKIPPED FILES:');
    console.log('-'.repeat(40));
    report.skipped.forEach((item, index) => {
      console.log(`${index + 1}. ${item.namespace}`);
      console.log(`   Source: ${item.source}`);
      console.log(`   Reason: ${item.reason}`);
      console.log('');
    });
  }
  
  if (report.errors.length > 0) {
    console.log('❌ ERRORS:');
    console.log('-'.repeat(40));
    report.errors.forEach((item, index) => {
      console.log(`${index + 1}. ${item.namespace}`);
      console.log(`   Source: ${item.source}`);
      console.log(`   Target: ${item.target}`);
      console.log(`   Error: ${item.error}`);
      console.log('');
    });
  }
  
  console.log('='.repeat(60));
  console.log('📋 SUMMARY:');
  console.log(`- ${report.copied.length} files copied successfully`);
  console.log(`- ${report.skipped.length} files skipped (no ${requiredFile} in target)`);
  console.log(`- ${report.errors.length} files failed to copy`);
  console.log('='.repeat(60));
}

// Main execution
function main() {
  // Check if source directory exists
  if (!fs.existsSync(sourceDir)) {
    console.error(`Source directory '${sourceDir}' does not exist!`);
    process.exit(1);
  }

  // Check if target base directory exists
  if (!fs.existsSync(targetBaseDir)) {
    console.error(`Target base directory '${targetBaseDir}' does not exist!`);
    process.exit(1);
  }

  console.log('Processing directories...');
  console.log('');

  // Process the source directory
  processDirectory(sourceDir);

  // Print detailed report
  printReport();
}

// Run the script
main(); 