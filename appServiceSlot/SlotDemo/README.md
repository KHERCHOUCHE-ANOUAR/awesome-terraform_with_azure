# Simple Slot Demo

This is a minimal ASP.NET Core 8.0 application that visually demonstrates the difference between Production and Staging Slot deployments in Azure App Service.

## Features

- **Production Environment**: Purple gradient background with green badge showing "Production"
- **Staging Slot**: Pink/Red gradient background with red badge showing the slot name
- **Real-time Information**: Shows slot name, environment, hostname, and timestamp
- **Single File**: Everything is in Program.cs - no controllers, no views, just simple

## What You'll See

### Production (master branch)
- 🚀 Rocket emoji
- Purple background
- Green "Production" badge
- URL: https://myapp-app.azurewebsites.net

### Staging Slot (appServiceSlot_Working_DO_NOT_MERGE branch)
- 🧪 Test tube emoji
- Pink/Red background
- Red slot name badge
- URL: https://myapp-app-myapp-slot.azurewebsites.net

## Project Structure

```
simple-slot-demo/
├── Program.cs           # Single file with everything
├── SlotDemo.csproj     # Project file
└── appsettings.json    # Configuration
```

## How to Deploy

1. Replace the contents of `appServiceSlot/SlotDemo/` with these files
2. Commit and push to `master` branch for Production
3. Commit and push to `appServiceSlot_Working_DO_NOT_MERGE` branch for Staging Slot
4. GitHub Actions will automatically deploy to the respective environments

## Testing

After deployment:
- Visit your production URL - you'll see a purple page with "Production"
- Visit your slot URL - you'll see a pink/red page with your slot name
- The pages are clearly different so you can instantly see which environment you're on!
