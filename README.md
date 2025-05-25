# VehicleSaverV

<a href="https://github.com/LouiDev/VehicleSaverV/releases">![Latest](https://img.shields.io/github/v/release/louidev/VehicleSaverV)</a>

VehicleSaverV is a simple library for [SHVDN3](https://github.com/scripthookvdotnet) allowing you to read / write `Vehicle`s from / as JSON objects.
Latest build can be found [here](https://github.com/LouiDev/VehicleSaverV/releases).

Vehicle data that can be converted:
- Vehicle model
- Vehicle colors
- Vehicle mods
- Vehicle neon lights
- Vehicle license plate

If you have suggestions, questions or feedback, hit me up on [Discord](https://discord.com/invite/U2KGVbj3uh), this is the quickest way to get a response!

# How to use
Download the **latest version** of [SHVDN3](https://github.com/scripthookvdotnet) & [VehicleSaverV](https://img.shields.io/github/v/release/louidev/VehicleSaverV) and add them to your prject.

## Converting to JSON
Converting a `Vehicle` to JSON:
```C#
string json = vehicle.ToJson();
```

Alternatively, you can get the vehicle's `VehicleData` first and then turn it into JSON:
```C#
VehicleData vehicleData = vehicle.GetVehicleData();
string json = vehicleData.ToJson();
```

## Converting to Vehicle
Converting a json object to `VehicleData`:
```C#
VehicleData vehicleData = VehicleData.FromJson(json);
```

You can then spawn the `Vehicle` from that data:
```C#
Vehicle vehicle = vehicleData.CreateVehicle(spawnPosition, heading);
```
