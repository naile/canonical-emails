# CanonicalEmails
[![Build status](https://ci.appveyor.com/api/projects/status/uw5tdp1n21u54dug/branch/master?svg=true)](https://ci.appveyor.com/project/naile/canonical-emails/branch/master)
[![CanonicalEmails](https://img.shields.io/badge/Nuget-v1.0.1-blue.svg)](https://www.nuget.org/packages/CanonicalEmails/)

A tiny .NET Core library for email normalization. 
Inspired by [normailize](https://github.com/soundcloud/normailize)



## Installation

`PM> Install-Package CanonicalEmails `



## Usage

```C#
var email = new MailAddress("jane.doe+foo@gmail.com")
var normalized = Normalizer.Normalize(email) // => janedoe@gmail.com
    
// or as extension
normalized = email.Normalize() // => janedoe@gmail.com
    
```



## Configuration 

```C#
var settings = new NormalizerSettings
{
	RemoveDots = true, // Remove "." for applicable domains
	RemoveTags = true, // Remove tags (ex: '+' and '-') for applicable domains)
	LowerCase = true, // Lowercase
	NormalizeHost = true // googlemail.com => gmail.com)
}

Normalizer.Normalize(email, settings)
    
// or globally
Normalizer.ConfigureDefaults(settings);

```



Support for gmail, hotmail, live.com, outlook, yahoo, protonmail and a few more.



## License

MIT

