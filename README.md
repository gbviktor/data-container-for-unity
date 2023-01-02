# Data Container for Unity (Experimental)
This package help you combine Data/Types together and make it easy to access like one object.  
*(yes, this is something's what look like a Resource Locator)*

## Install with Unity Package Manager
- in Unity go to *Windows > Package Manager*
- press ` + ` and select ` Add package from git URL...`
```cmd
https://github.com/gbviktor/data-container-for-unity.git
```

Perfect way to combine/link different types/classes of User Data and access it simply, for Example:  
- (Actual way) if you fetch *UserProfile*, *Garage*, *Notifications*, *GameSettings* from Backend Server
> Normally, you will be create a wrapper class with fields like:
```csharp
public class User{
	private long uid;
	private Garage garage;
	private Notifications notifications;
	private GameSettings gameSettings;
	//etc...
	//not bad way, but now, i don't like this
}
```

> I like use this Package to get data what I need inside a class where I am use it

```csharp
private void renderNotifications(IData data){

	if(!data.Get(out Notifications notifications))
	{
		throw new Exception("not found Notifications Data");
	}
	//do your stuff with notifications var
}
```

## Getting Started

>Implement interface ` IData ` inside your Types, what you like to bind/link/attach together

> Important! 
> Initialize once your data container before attach other objects, like:

```csharp
var user = new User().InitDataContainer();
user.Attach(await NotificationsService.getFor(user));
user.Attach(new GameSettings());
```

## How to get/link/attach interface ?

```csharp
data.Attach<ISomeInterface>(objectOfSomeClass);
```

## How to get/link/attach base class ?

```csharp
//player is of type GameObject
data.Attach<Object>(player);
//or, but not recommended
data.Attach(player as Object);
```
