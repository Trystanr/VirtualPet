# Virtual Pet

This is a demo project which aims to showcase the cross-platform features of C# and Xamarin forms.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

For development, the latest version of Visual Studio is required. The latest version can be downloaded from [here](https://visualstudio.microsoft.com/downloads/).

<!--A step by step series of examples that tell you how to get a development env running-->
### Installing

1. Clone the repo
```sh
git clone https:://github.com/Trystanr/VirtualPet.git
```
2. Open the project

Use `Open Workspace` in Visual Studio.

3. Ensure the following Nuget packages are installed:
  - [Coverlet Collector](https://www.nuget.org/packages/coverlet.collector/)
  - [.NET Test SKD](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/16.6.0-preview-20200318-01)
  - [TestAdapter](https://www.nuget.org/packages/MSTest.TestAdapter/)
  - [TestFramework](https://www.nuget.org/packages/MSTest.TestFramework/)
  - [Xamarin.Essentials](https://www.nuget.org/packages/Xamarin.Essentials/)
  - [Xamarin.Forms](https://www.nuget.org/packages/Xamarin.Forms/4.6.0.494-pre2)
  - [Xamarin.Forms.InputKit](https://www.nuget.org/packages/Xamarin.Forms.InputKit/3.3.0-pre.3)

4. The folliwing simulators were used for deployment:
  - iOS - iPhone 11 iOS 13.3
  - Android - Pixel 2 (API 28)

5. If there is an error, complete the following steps:
  - Clean the project
  - Remove all Nuget packages
  - Reinstall all Nuget packages
  - Close VS
  - Open VS
  - Rebuild and run the app

## Unit Tests

These are the unit tests that can be run on this system

### getHungerStateFull

This test checks if the correct hunger state is returned based on a string. 
Navigate to Test Explorer and run unit tests.

```C#
Assert.AreEqual(PetHungerStates.GetPetHungerState("full"), PetHungerState.full);
```

### getHungerStateStarving

This test checks if the correct hunger state is returned based on a string. 
Navigate to Test Explorer and run unit tests.

```C#
Assert.AreEqual(PetHungerStates.GetPetHungerState("starving"), PetHungerState.starving);
```

### getHungerStateFromValue

This test checks if the correct hunger state is returned based on a hunger integer. 
Navigate to Test Explorer and run unit tests.

```C#
int hungerValue = 15;
Assert.AreEqual(PetHungerStates.GetStateFromHunger(hungerValue), PetHungerState.starving);
```

## Built With

  * [Coverlet Collector](https://www.nuget.org/packages/coverlet.collector/)
  * [.NET Test SKD](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/16.6.0-preview-20200318-01)
  * [TestAdapter](https://www.nuget.org/packages/MSTest.TestAdapter/)
  * [TestFramework](https://www.nuget.org/packages/MSTest.TestFramework/)
  * [Xamarin.Essentials](https://www.nuget.org/packages/Xamarin.Essentials/)
  * [Xamarin.Forms](https://www.nuget.org/packages/Xamarin.Forms/4.6.0.494-pre2)
  * [Xamarin.Forms.InputKit](https://www.nuget.org/packages/Xamarin.Forms.InputKit/3.3.0-pre.3)

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Authors

* **Trystan Rivers** - *Front End & Unit Testing* - [Trystanr](https://github.com/Trystanr)

See also the list of [contributors](https://github.com/Trystanr/VirtualPet/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* Armand & Paul - top lecturers, couldn't do the project without their help
