# RdXmlLibrary
Library of RD.xml files for NativeAOT

## Introduction

Currently compiling existing application using NativeAOT is non-trivial task where you should refactor you application, nudge ILC to add nescessary types missed during static analysis due to required reflection usage, etc.

This project want reduce pain during RD.xml creation by providing set of RD.xml files for libraries in the ecosystem.

## How to use

Look at the libraries which your app is using and add nescessary rd.xml files. For example if you using Avalonia and Sqlite with EF Core, copy files `Avalonia.rd.xml`, `Microsoft.EntityFrameworkCore.rd.xml` and `Microsoft.EntityFrameworkCore.Sqlite.rd.xml` to your app entry project, and add following snipped to your project file.
```
<ItemGroup>
  <RdXmlFile Include="Avalonia.rd.xml" />
  <RdXmlFile Include="Microsoft.EntityFrameworkCore.rd.xml" />
  <RdXmlFile Include="Microsoft.EntityFrameworkCore.Sqlite.rd.xml" />
</ItemGroup>
```

After that, if you need put customizations which are specific to your app, put them into `rd.xml` file.

## Related projects

- EF Core NativeAOT RdGenerator https://github.com/hez2010/EFCore.NativeAOT.RdGenerator

## Testing

```
dotnet test tests/
```

## License

This project is licensed under MIT.