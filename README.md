# Kentico Xperience Upsert Alternative Forms Provider
This Kentico Xperience provider enables using alternative forms named "upsert" to provide one alternative form for all page edit modes, including "insert", "update", and "newculture". This prevents having to create three alternative forms for a page type if you need to customize inherited fields.

## Background
With MVC development, its common to use Xperience's page type inheritance to have many page types that inherit common fields, like SEO fields. However, there are cases when you want to customize field control settings in the inherited version of the field settings. The only way to do this is to create alternative forms for a page type. However, this requires creating a separate alternative form for each edit mode, including "insert", "update", and "newculture". This custom provider allows creating one alternative form that will be used for all three edit modes. With this provider, you can create one alternative form named "upsert" to customize the page type's form for all modes. However, you can still create an "insert", "update", or "newculture" alternative form if you need to override the "upsert" one for a specific mode.

## Solution
The solution is to create a custom Kentico Xperience `AlternativeFormInfoProvider` and override the `GetInfoByFullName` method.  If the method fails to get an alternative form named "insert", "update", or "newculture" it tries to get one named "upsert".

## Compatibility
* .NET 4.6.1 or higher
* Kentico Xperience versions
  -  11.0.0 or higher (use KenticoCommunity.UpsertAlternativeForms 11.0.0)
  -  12.0.0 or higher (use KenticoCommunity.UpsertAlternativeForms 12.0.0)
  -  13.0.0 or higher (use KenticoCommunity.UpsertAlternativeForms 13.0.0)
  

## Installation
To install, add the NuGet package, "KenticoCommunity.UpsertAlternativeForms", to your CMS project. Also add the version of "Kentico.Libraries" that corresponds to the hotfix level of your Xperience installation, to ensure the dependencies of this package do not downgrade Xperience assemblies.

## Usage
After adding the NuGet package to your CMS project, you can create alternative forms for your page types named "upsert" whenever you want one alternative form for all edit modes.

## License

This project uses a standard MIT license which can be found [here](https://github.com/heywills/upsert-alternative-forms/blob/master/LICENSE).

## Contribution

Contributions are welcome. Feel free to submit pull requests to the repo.

## Support

Please report bugs as issues in this GitHub repo.  We'll respond as soon as possible.

