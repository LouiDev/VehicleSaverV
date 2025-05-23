using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using VehicleSaver.Serilization;

namespace VehicleSaver
{
    public static class VehicleExtensions
    {
        /// <summary>
        /// Gets the vehicle data used for JSON serialization.
        /// </summary>
        /// <param name="vehicle"></param>
        public static VehicleData GetVehicleData(this Vehicle vehicle)
        {
            List<SerilizableVehicleMod> mods = new List<SerilizableVehicleMod>();
            foreach (int type in Enum.GetValues(typeof(VehicleModType)))
            {
                var mod = vehicle.Mods[(VehicleModType)type];
                if (mod.Index != -1)
                {
                    mods.Add(new SerilizableVehicleMod
                    {
                        Variation = mod.Variation,
                        Index = mod.Index,
                        Type = (int)mod.Type
                    });
                }
            }

            List<int> toggleMods = new List<int>();
            foreach (int type in Enum.GetValues(typeof(VehicleToggleModType)))
            {
                var mod = vehicle.Mods[(VehicleToggleModType)type];
                if (mod.IsInstalled)
                    toggleMods.Add((int)mod.Type);
            }

            List<int> neonLights = new List<int>();
            foreach (var index in Enum.GetValues(typeof(VehicleNeonLight)))
            {
                if (vehicle.Mods.HasNeonLight((VehicleNeonLight)index))
                    neonLights.Add((int)index);
            }

            return new VehicleData
            {
                Model = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, vehicle.Model.Hash).ToLower(),
                WheelType = (int)vehicle.Mods.WheelType,
                LicensePlateStyle = (int)vehicle.Mods.LicensePlateStyle,
                Livery = vehicle.Mods.Livery,
                InstalledMods = mods.ToArray(),
                InstalledToggleMods = toggleMods.ToArray(),
                InstalledNeonLights = neonLights.ToArray(),
                Colors = new VehicleColors
                {
                    ColorCombination = vehicle.Mods.ColorCombination,
                    ColorCombinationCount = vehicle.Mods.ColorCombinationCount,
                    PrimaryColor = (int)vehicle.Mods.PrimaryColor,
                    SecondaryColor = (int)vehicle.Mods.SecondaryColor,
                    PearlescentColor = (int)vehicle.Mods.PearlescentColor,
                    RimColor = (int)vehicle.Mods.RimColor,
                    DashboardColor = (int)vehicle.Mods.DashboardColor,
                    TrimColor = (int)vehicle.Mods.TrimColor,
                    CustomPrimaryColor = new SerilizableColor(vehicle.Mods.CustomPrimaryColor),
                    CustomSecondaryColor = new SerilizableColor(vehicle.Mods.CustomSecondaryColor),
                    NeonLightsColor = new SerilizableColor(vehicle.Mods.NeonLightsColor),
                    TireSmokeColor = new SerilizableColor(vehicle.Mods.TireSmokeColor)
                },
            };
        }

        /// <summary>
        /// Serializes the vehicle data of this vehicle to JSON.
        /// </summary>
        /// <param name="vehicle"></param>
        public static string ToJson(this Vehicle vehicle) => new JavaScriptSerializer().Serialize(vehicle.GetVehicleData());
    }
}
