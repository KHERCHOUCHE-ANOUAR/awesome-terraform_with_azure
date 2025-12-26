var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Get the slot name from Azure environment variable
var slotName = Environment.GetEnvironmentVariable("WEBSITE_SLOT_NAME") ?? "Production";
var environment = app.Environment.EnvironmentName;

app.MapGet("/", () => Results.Content($@"
<!DOCTYPE html>
<html>
<head>
    <title>Slot Demo</title>
    <style>
        body {{
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background: {(slotName == "Production" ? "linear-gradient(135deg, #667eea 0%, #764ba2 100%)" : "linear-gradient(135deg, #f093fb 0%, #f5576c 100%)")};
        }}
        .container {{
            text-align: center;
            background: rgba(255,255,255,0.95);
            padding: 60px;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.3);
            max-width: 600px;
        }}
        h1 {{
            font-size: 3.5em;
            margin: 0 0 20px 0;
            color: #333;
        }}
        .slot-badge {{
            display: inline-block;
            padding: 15px 30px;
            background: {(slotName == "Production" ? "#48bb78" : "#f56565")};
            color: white;
            border-radius: 30px;
            font-size: 1.8em;
            font-weight: bold;
            margin: 20px 0;
            box-shadow: 0 4px 15px rgba(0,0,0,0.2);
        }}
        .info {{
            background: #f7fafc;
            padding: 25px;
            border-radius: 10px;
            margin-top: 30px;
            text-align: left;
        }}
        .info-row {{
            display: flex;
            justify-content: space-between;
            padding: 10px 0;
            border-bottom: 1px solid #e2e8f0;
        }}
        .info-row:last-child {{
            border-bottom: none;
        }}
        .label {{
            font-weight: bold;
            color: #4a5568;
        }}
        .value {{
            color: #2d3748;
            font-family: 'Courier New', monospace;
        }}
        .emoji {{
            font-size: 4em;
            margin-bottom: 10px;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='emoji'>{(slotName == "Production" ? "🚀" : "🧪")}</div>
        <h1>Slot Demo</h1>
        <div class='slot-badge'>{slotName}</div>
        
        <div class='info'>
            <div class='info-row'>
                <span class='label'>Slot Name:</span>
                <span class='value'>{slotName}</span>
            </div>
            <div class='info-row'>
                <span class='label'>Environment:</span>
                <span class='value'>{environment}</span>
            </div>
            <div class='info-row'>
                <span class='label'>Host Name:</span>
                <span class='value'>{Environment.MachineName}</span>
            </div>
            <div class='info-row'>
                <span class='label'>Timestamp:</span>
                <span class='value'>{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</span>
            </div>
        </div>
        
        <p style='margin-top: 30px; color: #718096;'>
            {(slotName == "Production" 
                ? "✅ This is the PRODUCTION environment" 
                : "⚠️ This is a STAGING SLOT environment")}
        </p>
    </div>
</body>
</html>", "text/html"));

app.Run();
