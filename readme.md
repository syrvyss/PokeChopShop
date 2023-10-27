# PokeChop Shop

PokeChop shop is a very real marketplace for buying Pokémon meat.

## Installation (macOS)

Use the package manager [brew](https://brew.sh/) to install dotnet.

```bash
brew install dotnet
```

## Contributing

* New features are only to be added using new branch called `feature/THIS_IS_A_NEW_FEATURE`
* `feature` brances are only to be merged into `develop`
* `develop` is never to be edited directly, except in case of syntax errors or other similar cases.
* `develop` is only to be merged into `master` when thorough testing has been made and all unit tests pass.


## Run migrations

### Add migration

```bash
dotnet ef migrations add Initial
```

### Update database with latest migration

```bash
dotnet ef database update
```

## Usage

### Running a live server

```bash
dotnet watch
```

### Run project normally

```bash
dotnet run
```

### Run unit tests

```bash
dotnet test
```

## License

[GPL3](https://choosealicense.com/licenses/gpl-3.0/)