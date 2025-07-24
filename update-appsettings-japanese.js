const fs = require('fs');
const path = require('path');

// Configuration
const appsettingsPath = 'GameRoundResult.Web/appsettings.json';
const japaneseCulture = 'ja-JP';

console.log('Updating appsettings.json to include Japanese culture...');
console.log(`Appsettings path: ${appsettingsPath}`);
console.log(`Japanese culture code: ${japaneseCulture}`);
console.log('');

function updateAppsettings() {
  try {
    // Read the appsettings.json file
    const appsettingsContent = fs.readFileSync(appsettingsPath, 'utf8');
    const appsettings = JSON.parse(appsettingsContent);

    // Check if Japanese culture is already in the SupportedCultures array
    if (appsettings.SupportedCultures && Array.isArray(appsettings.SupportedCultures)) {
      if (appsettings.SupportedCultures.includes(japaneseCulture)) {
        console.log(`✓ Japanese culture '${japaneseCulture}' is already in SupportedCultures`);
        return;
      }

      // Add Japanese culture to the array
      appsettings.SupportedCultures.push(japaneseCulture);

      // Sort the cultures alphabetically for consistency
      appsettings.SupportedCultures.sort();

      console.log(`✓ Added '${japaneseCulture}' to SupportedCultures`);
      console.log(`Updated SupportedCultures: [${appsettings.SupportedCultures.join(', ')}]`);
    } else {
      console.error('✗ SupportedCultures is not found or is not an array in appsettings.json');
      return;
    }

    // Write the updated content back to the file
    const updatedContent = JSON.stringify(appsettings, null, 2);
    fs.writeFileSync(appsettingsPath, updatedContent, 'utf8');

    console.log('');
    console.log('✓ Successfully updated appsettings.json');
    console.log('');
    console.log('Next steps:');
    console.log('1. Run the copy script to copy Japanese language files');
    console.log('2. Test the application with Japanese culture');
    console.log('3. Update other appsettings files in Configs/ if needed');

  } catch (error) {
    console.error(`✗ Error updating appsettings.json: ${error.message}`);
    process.exit(1);
  }
}

// Run the update
updateAppsettings(); 