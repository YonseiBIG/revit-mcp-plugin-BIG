# revit-mcp-plugin-BIG

> Forked from [mcp-servers-for-revit/revit-mcp-plugin](https://github.com/mcp-servers-for-revit/revit-mcp-plugin)
> Maintained by [YonseiBIG](https://github.com/YonseiBIG)

## Note

This repository is a fork of the original revit-mcp-plugin. **No code modifications** have been made — it serves as the plugin framework (Layer 2) for the YonseiBIG revit-mcp ecosystem.

For the actual extended functionality, see:
- [revit-mcp-BIG](https://github.com/YonseiBIG/revit-mcp-BIG) — MCP Server with 17 added tools
- [revit-mcp-commandset-BIG](https://github.com/YonseiBIG/revit-mcp-commandset-BIG) — Command Set with 17 added commands

---

## Introduction

revit-mcp-plugin is a Revit plugin based on the MCP protocol, enabling AI to interact with Revit.

This project is part of the revit-mcp project (receives messages, loads command sets, operates Revit), and needs to be used in conjunction with [revit-mcp-BIG](https://github.com/YonseiBIG/revit-mcp-BIG) (provides tools to AI) and [revit-mcp-commandset-BIG](https://github.com/YonseiBIG/revit-mcp-commandset-BIG) (specific feature implementations).

## Environment Requirements

- Revit 2019~2024

## Usage Instructions

### Register Plugin

Register the plugin and restart Revit:

```xml
<?xml version="1.0" encoding="utf-8"?>
<RevitAddIns>
  <AddIn Type="Application">
    <Name>revit-mcp</Name>
    <Assembly>%your_path%\revit-mcp-plugin.dll</Assembly>
    <FullClassName>revit_mcp_plugin.Core.Application</FullClassName>
    <ClientId>090A4C8C-61DC-426D-87DF-E4BAE0F80EC1</ClientId>
    <VendorId>revit-mcp</VendorId>
    <VendorDescription>https://github.com/YonseiBIG/revit-mcp-plugin-BIG</VendorDescription>
  </AddIn>
</RevitAddIns>
```

`%your_path%` needs to be replaced with the actual path after compilation.

### Configure Commands

Add-in Modules -> Revit MCP Plugin -> Settings

This interface is used to configure the commands to be loaded into Revit. Click OpenCommandSetFolder to open the folder storing command sets.

### Enable Service

Add-in -> Revit MCP Plugin -> Revit MCP Switch

Open the service to allow AI to discover your Revit program.

> Note: If you modify the configured commands after enabling the service, you may need to restart REVIT for the configuration to take effect.

## Related Repositories

| Repository | Role |
|---|---|
| [revit-mcp-BIG](https://github.com/YonseiBIG/revit-mcp-BIG) | TypeScript MCP Server (Layer 1) |
| [revit-mcp-commandset-BIG](https://github.com/YonseiBIG/revit-mcp-commandset-BIG) | C# Command Set (Layer 3) |
| [revit-mcp-plugin-BIG](https://github.com/YonseiBIG/revit-mcp-plugin-BIG) | C# Plugin Framework (Layer 2) — this repo |

## License

MIT

## Credits

- Original project: [mcp-servers-for-revit](https://github.com/mcp-servers-for-revit)
- Maintained by: [YonseiBIG](https://github.com/YonseiBIG)
