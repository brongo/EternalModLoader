﻿using EternalModLoader.Mods;
using EternalModLoader.Mods.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EternalModLoader
{
    /// <summary>
    /// Hard-coded mods for online multiplayer safety
    /// </summary>
    public static class OnlineSafety
    {
        /// <summary>
        /// Parent mod for the online safety hard-coded mods
        /// </summary>
        private static Mod ParentMod = new Mod()
        {
            LoadPriority = int.MinValue,
            RequiredVersion = EternalModLoader.Version
        };

        /// <summary>
        /// BlangJson that modifies the "Multiplayer" menu label to "Multiplayer (Disabled)"
        /// </summary>
        private static byte[] BlangJsonMultiplayerDisabled = new byte[]
        {
            0x7B, 0x0A, 0x20, 0x20, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x20, 0x5B,
            0x0A, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x7B, 0x0A, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,
            0x20, 0x20, 0x22, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x3A, 0x20, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F,
            0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D, 0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C,
            0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C, 0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C,
            0x0A, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x20, 0x22, 0x5E, 0x31, 0x4D, 0x75, 0x6C, 0x74, 0x69, 0x70, 0x6C, 0x61, 0x79, 0x65, 0x72,
            0x20, 0x28, 0x44, 0x69, 0x73, 0x61, 0x62, 0x6C, 0x65, 0x64, 0x29, 0x5E, 0x37, 0x22, 0x2C, 0x0A,
            0x09, 0x20, 0x20, 0x7D, 0x0A, 0x20, 0x20, 0x5D, 0x0A, 0x7D
        };

        /// <summary>
        /// ResourceModFile objects that contain the hard-coded mod that disables the multiplayer menu
        /// </summary>
        public static List<ResourceModFile> MultiplayerDisablerMod = new List<ResourceModFile>()
        {
            // Modified multiplayer menu decl that removes its functionality
            new ResourceModFile(ParentMod, "generated/decls/menuelement/main_menu/screens/multiplayer.decl", "gameresources_patch2")
            {
                FileData = new MemoryStream(new byte[]
                {
                    0x7B, 0x0D, 0x0A, 0x09, 0x69, 0x6E, 0x68, 0x65, 0x72, 0x69, 0x74, 0x20, 0x3D, 0x20, 0x22, 0x64,
                    0x65, 0x66, 0x61, 0x75, 0x6C, 0x74, 0x5F, 0x74, 0x72, 0x61, 0x6E, 0x73, 0x69, 0x74, 0x69, 0x6F,
                    0x6E, 0x22, 0x3B, 0x0D, 0x0A, 0x09, 0x65, 0x64, 0x69, 0x74, 0x20, 0x3D, 0x20, 0x7B, 0x0D, 0x0A,
                    0x09, 0x09, 0x73, 0x77, 0x66, 0x49, 0x6E, 0x66, 0x6F, 0x20, 0x3D, 0x20, 0x7B, 0x0D, 0x0A, 0x09,
                    0x09, 0x09, 0x73, 0x77, 0x66, 0x20, 0x3D, 0x20, 0x22, 0x73, 0x77, 0x66, 0x2F, 0x6D, 0x61, 0x69,
                    0x6E, 0x5F, 0x6D, 0x65, 0x6E, 0x75, 0x2F, 0x73, 0x63, 0x72, 0x65, 0x65, 0x6E, 0x73, 0x2F, 0x67,
                    0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x2E, 0x73, 0x77, 0x66, 0x22, 0x3B, 0x0D, 0x0A, 0x09, 0x09,
                    0x7D, 0x0D, 0x0A, 0x09, 0x09, 0x63, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x3D, 0x20, 0x22, 0x22, 0x3B,
                    0x0D, 0x0A, 0x09, 0x09, 0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4E, 0x61, 0x6D, 0x65, 0x20,
                    0x3D, 0x20, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D, 0x61, 0x69,
                    0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C, 0x69, 0x6E,
                    0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x3B, 0x0D, 0x0A, 0x09, 0x09, 0x67, 0x61, 0x6D, 0x65,
                    0x49, 0x6E, 0x66, 0x6F, 0x20, 0x3D, 0x20, 0x7B, 0x0D, 0x0A, 0x09, 0x09, 0x09, 0x63, 0x61, 0x6D,
                    0x65, 0x72, 0x61, 0x50, 0x6C, 0x61, 0x63, 0x65, 0x6D, 0x65, 0x6E, 0x74, 0x20, 0x3D, 0x20, 0x22,
                    0x63, 0x61, 0x6D, 0x65, 0x72, 0x61, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C, 0x69,
                    0x6E, 0x65, 0x22, 0x3B, 0x0D, 0x0A, 0x09, 0x09, 0x7D, 0x0D, 0x0A, 0x09, 0x09, 0x63, 0x68, 0x69,
                    0x6C, 0x64, 0x45, 0x6C, 0x65, 0x6D, 0x65, 0x6E, 0x74, 0x73, 0x20, 0x3D, 0x20, 0x7B, 0x0D, 0x0A,
                    0x09, 0x09, 0x09, 0x6E, 0x75, 0x6D, 0x20, 0x3D, 0x20, 0x31, 0x3B, 0x0D, 0x0A, 0x09, 0x09, 0x09,
                    0x69, 0x74, 0x65, 0x6D, 0x5B, 0x30, 0x5D, 0x20, 0x3D, 0x20, 0x22, 0x6F, 0x70, 0x74, 0x69, 0x6F,
                    0x6E, 0x73, 0x5F, 0x6C, 0x69, 0x73, 0x74, 0x5F, 0x63, 0x61, 0x74, 0x65, 0x67, 0x6F, 0x72, 0x79,
                    0x22, 0x3B, 0x0D, 0x0A, 0x09, 0x09, 0x7D, 0x0D, 0x0A, 0x09, 0x7D, 0x0D, 0x0A, 0x7D
                })
            },
            // Add the "Multiplayer (Disabled)" string to all the localization files
            new ResourceModFile(ParentMod, "EternalMod/strings/french.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/italian.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/german.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/spanish.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/russian.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/polish.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/japanese.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/latin_spanish.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/portuguese.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/traditional_chinese.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/simplified_chinese.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/korean.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            },
            new ResourceModFile(ParentMod, "EternalMod/strings/english.json", "gameresources_patch2")
            {
                IsBlangJson = true,
                FileData = new MemoryStream(BlangJsonMultiplayerDisabled, 0, BlangJsonMultiplayerDisabled.Length, false, true)
            }
        };

        /// <summary>
        /// Online-safe map resource types for assets
        /// </summary>
        public static string[] OnlineSafeMapResourceTypes = new string[]
        {
            "advancedscreenviewshake",
            "ambientsh",
            "audiolog",
            "audiologstory",
            "automap",
            "automapplayerprofile",
            "automapproperties",
            "automapsoundprofile",
            "basemodel",
            "binarygorecontainer",
            "binarymd6def",
            "binaryrig",
            "colorlut",
            "cswf",
            "env",
            "font",
            "fontfx",
            "fx",
            "gameitem",
            "globalfonttable",
            "gorebehavior",
            "gorecontainer",
            "gorewounds",
            "handsbobcycle",
            "havokragdoll",
            "havokshape",
            "highlightlos",
            "highlights",
            "hitconfirmationsoundsinfo",
            "hud",
            "hudelement",
            "image",
            "lightrig",
            "lodgroup",
            "material2",
            "md6def",
            "model",
            "modelasset",
            "modelstream",
            "particle",
            "particlestage",
            "renderlayerdefinition",
            "renderparm",
            "renderparmmeta",
            "renderprogdatabase",
            "renderprogflag",
            "renderprogresource",
            "ribbon2",
            "rumble",
            "screenviewshake",
            "soundevent",
            "soundpack",
            "soundrtpc",
            "soundstate",
            "soundswitch",
            "speaker",
            "staticimage",
            "swfresources",
            "uianchor",
            "uicolor",
            "weaponreticle",
            "weaponreticleswfinfo",
            "impacteffect",
            "uiweapon",
            "globalinitialwarehouse",
            "globalshell",
            "warehouseitem",
            "warehouseofflinecontainer"
        };

        /// <summary>
        /// Online-safe mod name keywords
        /// </summary>
        public static string[] OnlineSafeModNameKeywords = new string[]
        {
            "/eternalmod/",
            ".tga",
            ".png",
            ".swf",
            ".bimage",
            "/advancedscreenviewshake/",
            "/audiolog/",
            "/audiologstory/",
            "/automap/",
            "/automapplayerprofile/",
            "/automapproperties/",
            "/automapsoundprofile/",
            "/env/",
            "/font/",
            "/fontfx/",
            "/fx/",
            "/gameitem/",
            "/globalfonttable/",
            "/gorebehavior/",
            "/gorecontainer/",
            "/gorewounds/",
            "/handsbobcycle/",
            "/highlightlos/",
            "/highlights/",
            "/hitconfirmationsoundsinfo/",
            "/hud/",
            "/hudelement/",
            "/lightrig/",
            "/lodgroup/",
            "/material2/",
            "/md6def/",
            "/modelasset/",
            "/particle/",
            "/particlestage/",
            "/renderlayerdefinition/",
            "/renderparm/",
            "/renderparmmeta/",
            "/renderprogflag/",
            "/ribbon2/",
            "/rumble/",
            "/soundevent/",
            "/soundpack/",
            "/soundrtpc/",
            "/soundstate/",
            "/soundswitch/",
            "/speaker/",
            "/staticimage/",
            "/swfresources/",
            "/uianchor/",
            "/uicolor/",
            "/weaponreticle/",
            "/weaponreticleswfinfo/",
            "/entitydef/light/",
            "/entitydef/fx",
            "/entitydef/",
            "/impacteffect/",
            "/uiweapon/",
            "/globalinitialwarehouse/",
            "/globalshell/",
            "/warehouseitem/",
            "/warehouseofflinecontainer/"
        };

        /// <summary>
        /// Determines whether or not the mod with the given name and resource name is safe for online play
        /// </summary>
        /// <param name="mod">mod</param>
        /// <returns>whether or not the mod with the given name and resource name is safe for online play</returns>
        public static bool IsModSafeForOnline(ResourceModFile mod)
        {
            if (mod.IsAssetsInfoJson)
            {
                if (mod.AssetsInfo != null)
                {
                    // Restrict new assets by map resource type
                    if (mod.AssetsInfo.Assets != null)
                    {
                        // Don't allow any new assets in multiplayer maps
                        if (mod.ResourceName.StartsWith("pvp", StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }

                        foreach (var asset in mod.AssetsInfo.Assets)
                        {
                            if (!OnlineSafeMapResourceTypes.Contains(asset.MapResourceType.ToLowerInvariant()))
                            {
                                return false;
                            }
                        }
                    }

                    // Don't allow adding resources to the multiplayer maps
                    if (mod.AssetsInfo.Resources != null && mod.ResourceName.StartsWith("pvp", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }

            // Allow modification of anything outside "generated/decls/"
            if (!mod.Name.StartsWith("generated/decls/", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return OnlineSafeModNameKeywords.Any(keyword => mod.Name.Contains(keyword));
        }
    }
}
