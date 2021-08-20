# Xamarin.Forms Dependency Injection Study
This repository contains a Xamarin.Forms application for studying Dependency Injection. The app loads a list of Tennesse State Parks from the [Find a Park endpoint](https://gis.tnstateparks.com/datasets/TDEC::find-a-park-data/about).

Android | iOS
:---: | :---:
| <img src="images/ios.png" height="640" /> | <img src="images/android.png" height="640" />

## Studies

### [No Dependency Injection](/NoDependencyInjection)

No dependency injection involves instantiating classes directly where they are called.

```csharp
namespace NoDependencyInjection.Services
{
    public class ParkService
    {
        private readonly HttpClient _client;

        public ParkService()
        {
            _client = new HttpClient();
        }

        ...
    }
}
```

![](images/no-dependency-injection.jpg)

**Benefits**

* "Quick and dirty" way to write code

**Trade-offs**

* No separation of concerns
* Classes are open for modification (violates Open/Closed Principle)
* Not suitable for production grade apps with multiple services

### [Service Locator Pattern](/ServiceLocatorPattern)

The service locator pattern stores concrete implementations of classes in a service container. Those concretions are then accessed by calling the container directly.

This pattern can be used with or without a dependency injection library like [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection). I studied both approaches. See the [ServiceLocatorStatic](ServiceLocatorStatic) solution for an example that does not use a library.

```c#
namespace ServiceLocator.Services
{
    public class ParkService
    {
        private readonly HttpClient _client;

        public ParkService()
        {
            _client = Dependencies.ServiceProvider.GetRequiredService<HttpClient>();
        }

        ...
    }
}
```

![](images/service-locator-pattern.jpg)

**Benefits**

* Separation of concerns
* Easy to understand
* Just-in-time service requests (services are resolved at runtime rather than compile time)

**Trade-offs**

* Difficult to mock and unit test because code references the container
* Creates a global dependency (direct reference to the container)
* Difficult to identify what dependencies are used and where
* Can't detect missing dependencies before runtime

### Dependency Injection Pattern

The dependency injection pattern allows the service container to orchestrate all dependencies indepent of the classes that dependent on them.

```c#
namespace DependencyInjection.Services
{
    public class ParkService
    {
        private readonly HttpClient _client;

        public ParkService(HttpClient client)
        {
            _client = client;
        }

        ...
    }
}
```

![](images/dependency-injection-pattern.jpg)

**Benefits**

* Code does not reference the container, only real dependencies
* Easy to identify which dependencies are used for each class
* Easy to mock dependencies and unit test classes

**Trade-offs**

* Steep learning curve
* Can degrade performance if not implemented correctly

## References

- [Working with Remote Data in Xamarin.Forms Applications](https://www.pluralsight.com/courses/remote-data-xamarin-forms-applications)
- [Use a service locator to register and retrieve dependencies](https://docs.microsoft.com/en-us/learn/modules/explore-cross-platform-design-patterns/8-use-a-service-locator-to-register-and-retrieve-dependencies)
- [Use an IoC container to automatically inject dependencies](https://docs.microsoft.com/en-us/learn/modules/explore-cross-platform-design-patterns/10-use-an-ioc-container-to-automatically-inject-dependencies)
- [SOLID Principles for C# Developers](https://www.pluralsight.com/courses/csharp-solid-principles)