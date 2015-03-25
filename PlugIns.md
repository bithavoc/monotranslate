One thing to do it is convert the translators into plug-ins, so any user (with the apropiate knowledege) can write a translator wrapper and add it to the app.
This is going to be acomplished by using refelction and xml configuration files.

This page it's going to contain information about how to write a translator.

A demo plugin may be something like this:


```
using System;
using MonoTranslate.Plugins;

[assembly: PluginsPackage(Name="extra-translators",Description="")]
[assembly: PluginsPackageAuthor("Johan.Hernandez <thepumpkin1979@gmail.com>")]

namespace MMGoogle
{
 [Plugin(Name="Google-Integration",Description="Google translation Engine")]
 public class SoundIntegrationPlugin : ServicePlugin
 {
    protected override OnInit(OnInitArgs args)
    {
      //this.Context.MonoTranslate.Quit();
      //this.Context.MonoTranslate.Restart();
      //this.Context.MonoTranslate.ShowMessage(string);
      //this.Context.MonoTranslate.Maximize(string);
      //Invoke Xml Web Service
      //other statements...
    }
 }
 [Plugin(Name="other-plugin",Description="Other plugin...")]
 public class OtherPlugin : ServicePlugin
 {
 }
}
```

Deployment:
  * Linux:
```
cp plugin-package.dll $HOME/.monotranslate/plugins/
```

  * Windows:
```
copy plugin-package.dll C:\Program Files\MonoTranslate\Plugins\
```