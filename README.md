# Discogg

A Blazor WebAssembly application for managing your Discogs collection, wantlist, and marketplace listings.

## Features

- Browse and search the Discogs database
- Manage your collection and wantlist
- OAuth authentication with Discogs
- Dark/light theme support
- German localization

## Requirements

- .NET 8.0 SDK
- A Discogs API token (obtain at https://www.discogs.com/settings/developers)

## Building

```bash
dotnet build Discogg.sln
```

## Running

```bash
cd Application
dotnet run
```

## Testing

```bash
dotnet test
```

## Project Structure

- `Application/` - Blazor WebAssembly frontend
- `Discogs.API/` - Core API client library
- `Discogs.API.Tests/` - Unit tests

## API Documentation

This project uses the Discogs API. See https://www.discogs.com/developers for full API documentation.

## License

MIT