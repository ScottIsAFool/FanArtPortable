# Fanart Portable #

## What is it? ##
Fanart Portable is a Portable Class Library that gives developers access to the Fanart film, TV and music image resources ([www.fanart.tv](http://fanart.tv)).

## What targets does it have? ##
It targets ***everything***!!! So that's .NET 4.0.3+, Silverlight 5, Windows Store apps, Windows Phone 7.5, Windows Phone 8.

## Anything cool and unexpected? ##
Yeah, all the classes implement INotifyPropertyChanged to make it easier if you want to use them in an MVVM approach. There is also an `IFanArtClient` interface if you want to use it that way.

## How do I install it? ##
Nuget. Basically. 

PM> Install-Package FanArtPortable
