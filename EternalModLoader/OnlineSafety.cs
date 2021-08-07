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
        private static Mod s_parentMod = new Mod()
        {
            LoadPriority = int.MinValue,
            RequiredVersion = EternalModLoader.Version
        };

        /// <summary>
        /// BlangJson for the english multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledEnglish = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x4D, 0x55, 0x4C, 0x54, 0x49, 0x50, 0x4C, 0x41, 0x59, 0x45, 0x52, 0x20,
            0x28, 0x44, 0x49, 0x53, 0x41, 0x42, 0x4C, 0x45, 0x44, 0x29, 0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the french multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledFrench = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x4D, 0x55, 0x4C, 0x54, 0x49, 0x4A, 0x4F, 0x55, 0x45, 0x55, 0x52, 0x20,
            0x28, 0x44, 0xC3, 0x89, 0x53, 0x41, 0x43, 0x54, 0x49, 0x56, 0xC3, 0x89, 0x29, 0x22, 0x7D, 0x5D,
            0x7D
        };

        /// <summary>
        /// BlangJson for the german multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledGerman = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x4D, 0x55, 0x4C, 0x54, 0x49, 0x50, 0x4C, 0x41, 0x59, 0x45, 0x52, 0x20,
            0x28, 0x44, 0x45, 0x41, 0x4B, 0x54, 0x49, 0x56, 0x49, 0x45, 0x52, 0x54, 0x29, 0x22, 0x7D, 0x5D,
            0x7D
        };

        /// <summary>
        /// BlangJson for the italian multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledItalian = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x4D, 0x55, 0x4C, 0x54, 0x49, 0x47, 0x49, 0x4F, 0x43, 0x41, 0x54, 0x4F,
            0x52, 0x45, 0x20, 0x28, 0x44, 0x49, 0x53, 0x41, 0x42, 0x49, 0x4C, 0x49, 0x54, 0x41, 0x54, 0x4F,
            0x29, 0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the japanese multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledJapanese = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0xE3, 0x83, 0x9E, 0xE3, 0x83, 0xAB, 0xE3, 0x83, 0x81, 0xE3, 0x83, 0x97,
            0xE3, 0x83, 0xAC, 0xE3, 0x82, 0xA4, 0xE3, 0x83, 0xA4, 0xE3, 0x83, 0xBC, 0x28, 0xE7, 0x84, 0xA1,
            0xE5, 0x8A, 0xB9, 0x29, 0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the korean multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledKorean = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0xEB, 0xA9, 0x80, 0xED, 0x8B, 0xB0, 0x20, 0xED, 0x94, 0x8C, 0xEB, 0xA0,
            0x88, 0xEC, 0x9D, 0xB4, 0x28, 0xEB, 0xB9, 0x84, 0xED, 0x99, 0x9C, 0xEC, 0x84, 0xB1, 0xED, 0x99,
            0x94, 0xEB, 0x90, 0xA8, 0x29, 0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the polish multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledPolish = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x47, 0x52, 0x41, 0x20, 0x57, 0x49, 0x45, 0x4C, 0x4F, 0x4F, 0x53, 0x4F,
            0x42, 0x4F, 0x57, 0x41, 0x20, 0x28, 0x44, 0x45, 0x5A, 0x41, 0x4B, 0x54, 0x59, 0x57, 0x4F, 0x57,
            0x41, 0x4E, 0x59, 0x29, 0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the portuguese multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledPortuguese = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x4D, 0x55, 0x4C, 0x54, 0x49, 0x4A, 0x4F, 0x47, 0x41, 0x44, 0x4F, 0x52,
            0x20, 0x28, 0x44, 0x45, 0x53, 0x41, 0x42, 0x49, 0x4C, 0x49, 0x54, 0x41, 0x44, 0x4F, 0x29, 0x22,
            0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the russian multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledRussian = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0xD0, 0xA1, 0xD0, 0x95, 0xD0, 0xA2, 0xD0, 0x95, 0xD0, 0x92, 0xD0, 0x90,
            0xD0, 0xAF, 0x20, 0xD0, 0x98, 0xD0, 0x93, 0xD0, 0xA0, 0xD0, 0x90, 0x20, 0x28, 0xD0, 0x9E, 0xD0,
            0xA2, 0xD0, 0x9A, 0xD0, 0x9B, 0xD0, 0xAE, 0xD0, 0xA7, 0xD0, 0x95, 0xD0, 0x9D, 0xD0, 0x90, 0x29,
            0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the simplified chinese multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledSimplifiedChinese = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0xE5, 0xA4, 0x9A, 0xE4, 0xBA, 0xBA, 0xE6, 0xB8, 0xB8, 0xE6, 0x88, 0x8F,
            0xEF, 0xBC, 0x88, 0xE5, 0xB7, 0xB2, 0xE7, 0xA6, 0x81, 0xE7, 0x94, 0xA8, 0xEF, 0xBC, 0x89, 0x22,
            0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the traditional chinese multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledTraditionalChinese = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0xE5, 0xA4, 0x9A, 0xE4, 0xBA, 0xBA, 0xE9, 0x80, 0xA3, 0xE7, 0xB7, 0x9A,
            0xEF, 0xBC, 0x88, 0xE5, 0xB7, 0xB2, 0xE7, 0xA6, 0x81, 0xE7, 0x94, 0xA8, 0xEF, 0xBC, 0x89, 0x22,
            0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// BlangJson for the spanish multiplayer menu label
        /// </summary>
        private static byte[] s_blangJsonMultiplayerDisabledSpanish = new byte[]
        {
            0x7B, 0x22, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x73, 0x22, 0x3A, 0x5B, 0x7B, 0x22, 0x6E, 0x61,
            0x6D, 0x65, 0x22, 0x3A, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D,
            0x61, 0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C,
            0x69, 0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x2C, 0x22, 0x74, 0x65, 0x78, 0x74, 0x22,
            0x3A, 0x22, 0x5E, 0x38, 0x4D, 0x55, 0x4C, 0x54, 0x49, 0x4A, 0x55, 0x47, 0x41, 0x44, 0x4F, 0x52,
            0x20, 0x28, 0x44, 0x45, 0x53, 0x48, 0x41, 0x42, 0x49, 0x4C, 0x49, 0x54, 0x41, 0x44, 0x4F, 0x29,
            0x22, 0x7D, 0x5D, 0x7D
        };

        /// <summary>
        /// Generic SWF data
        /// </summary>
        private static byte[] s_genericSWFData = new byte[]
        {
            0x25, 0x45, 0x70, 0x00, 0x00, 0x45, 0x07, 0x00, 0x00, 0x3C, 0x00, 0x40, 0x40, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x00, 0x2C, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x00,
            0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x02, 0x0A, 0x00, 0x00, 0x00, 0x72, 0x6F, 0x6C, 0x6C, 0x4F,
            0x6E, 0x42, 0x61, 0x63, 0x6B, 0x00, 0x00, 0x00, 0x0D, 0x0C, 0x00, 0x00, 0x00, 0x72, 0x6F, 0x6C,
            0x6C, 0x4F, 0x66, 0x66, 0x46, 0x72, 0x6F, 0x6E, 0x74, 0x00, 0x00, 0x00, 0x17, 0x0B, 0x00, 0x00,
            0x00, 0x72, 0x6F, 0x6C, 0x6C, 0x4F, 0x6E, 0x46, 0x72, 0x6F, 0x6E, 0x74, 0x00, 0x00, 0x00, 0x21,
            0x0B, 0x00, 0x00, 0x00, 0x72, 0x6F, 0x6C, 0x6C, 0x4F, 0x66, 0x66, 0x42, 0x61, 0x63, 0x6B, 0x00,
            0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x0E, 0x26, 0x01, 0x00, 0x01, 0x00,
            0x00, 0x5F, 0x63, 0x65, 0x6E, 0x74, 0x65, 0x72, 0x00, 0x00, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00,
            0x00, 0x67, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x5F, 0x66, 0x6C, 0x61, 0x2E, 0x4D, 0x61, 0x69,
            0x6E, 0x54, 0x69, 0x6D, 0x65, 0x6C, 0x69, 0x6E, 0x65, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x02, 0x00, 0x00, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x04,
            0xBE, 0x01, 0x00, 0x00, 0x00, 0x00, 0x10, 0x00, 0x2E, 0x00, 0x00, 0x00, 0x00, 0x34, 0x0B, 0x67,
            0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x5F, 0x66, 0x6C, 0x61, 0x0C, 0x4D, 0x61, 0x69, 0x6E, 0x54,
            0x69, 0x6D, 0x65, 0x6C, 0x69, 0x6E, 0x65, 0x0D, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x64, 0x69,
            0x73, 0x70, 0x6C, 0x61, 0x79, 0x09, 0x4D, 0x6F, 0x76, 0x69, 0x65, 0x43, 0x6C, 0x69, 0x70, 0x18,
            0x67, 0x65, 0x6E, 0x65, 0x72, 0x69, 0x63, 0x5F, 0x66, 0x6C, 0x61, 0x3A, 0x4D, 0x61, 0x69, 0x6E,
            0x54, 0x69, 0x6D, 0x65, 0x6C, 0x69, 0x6E, 0x65, 0x00, 0x07, 0x5F, 0x63, 0x65, 0x6E, 0x74, 0x65,
            0x72, 0x06, 0x66, 0x72, 0x61, 0x6D, 0x65, 0x31, 0x07, 0x66, 0x72, 0x61, 0x6D, 0x65, 0x31, 0x32,
            0x07, 0x66, 0x72, 0x61, 0x6D, 0x65, 0x32, 0x32, 0x07, 0x66, 0x72, 0x61, 0x6D, 0x65, 0x33, 0x32,
            0x07, 0x66, 0x72, 0x61, 0x6D, 0x65, 0x34, 0x33, 0x07, 0x76, 0x69, 0x73, 0x69, 0x62, 0x6C, 0x65,
            0x21, 0x68, 0x74, 0x74, 0x70, 0x3A, 0x2F, 0x2F, 0x61, 0x64, 0x6F, 0x62, 0x65, 0x2E, 0x63, 0x6F,
            0x6D, 0x2F, 0x41, 0x53, 0x33, 0x2F, 0x32, 0x30, 0x30, 0x36, 0x2F, 0x62, 0x75, 0x69, 0x6C, 0x74,
            0x69, 0x6E, 0x0B, 0x61, 0x64, 0x6F, 0x62, 0x65, 0x2E, 0x75, 0x74, 0x69, 0x6C, 0x73, 0x13, 0x66,
            0x6C, 0x61, 0x73, 0x68, 0x2E, 0x61, 0x63, 0x63, 0x65, 0x73, 0x73, 0x69, 0x62, 0x69, 0x6C, 0x69,
            0x74, 0x79, 0x0D, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x64, 0x65, 0x73, 0x6B, 0x74, 0x6F, 0x70,
            0x0C, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x65, 0x72, 0x72, 0x6F, 0x72, 0x73, 0x0C, 0x66, 0x6C,
            0x61, 0x73, 0x68, 0x2E, 0x65, 0x76, 0x65, 0x6E, 0x74, 0x73, 0x0E, 0x66, 0x6C, 0x61, 0x73, 0x68,
            0x2E, 0x65, 0x78, 0x74, 0x65, 0x72, 0x6E, 0x61, 0x6C, 0x0D, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E,
            0x66, 0x69, 0x6C, 0x74, 0x65, 0x72, 0x73, 0x0A, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x67, 0x65,
            0x6F, 0x6D, 0x13, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x67, 0x6C, 0x6F, 0x62, 0x61, 0x6C, 0x69,
            0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x0B, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x6D, 0x65, 0x64,
            0x69, 0x61, 0x09, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x6E, 0x65, 0x74, 0x0D, 0x66, 0x6C, 0x61,
            0x73, 0x68, 0x2E, 0x6E, 0x65, 0x74, 0x2E, 0x64, 0x72, 0x6D, 0x0E, 0x66, 0x6C, 0x61, 0x73, 0x68,
            0x2E, 0x70, 0x72, 0x69, 0x6E, 0x74, 0x69, 0x6E, 0x67, 0x0E, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E,
            0x70, 0x72, 0x6F, 0x66, 0x69, 0x6C, 0x65, 0x72, 0x0D, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x73,
            0x61, 0x6D, 0x70, 0x6C, 0x65, 0x72, 0x0D, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x73, 0x65, 0x6E,
            0x73, 0x6F, 0x72, 0x73, 0x0C, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x73, 0x79, 0x73, 0x74, 0x65,
            0x6D, 0x0A, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x74, 0x65, 0x78, 0x74, 0x0E, 0x66, 0x6C, 0x61,
            0x73, 0x68, 0x2E, 0x74, 0x65, 0x78, 0x74, 0x2E, 0x69, 0x6D, 0x65, 0x11, 0x66, 0x6C, 0x61, 0x73,
            0x68, 0x2E, 0x74, 0x65, 0x78, 0x74, 0x2E, 0x65, 0x6E, 0x67, 0x69, 0x6E, 0x65, 0x08, 0x66, 0x6C,
            0x61, 0x73, 0x68, 0x2E, 0x75, 0x69, 0x0B, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x75, 0x74, 0x69,
            0x6C, 0x73, 0x09, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x78, 0x6D, 0x6C, 0x17, 0x66, 0x6C, 0x61,
            0x73, 0x68, 0x2E, 0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x3A, 0x4D, 0x6F, 0x76, 0x69, 0x65,
            0x43, 0x6C, 0x69, 0x70, 0x14, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E, 0x64, 0x69, 0x73, 0x70, 0x6C,
            0x61, 0x79, 0x3A, 0x53, 0x70, 0x72, 0x69, 0x74, 0x65, 0x24, 0x66, 0x6C, 0x61, 0x73, 0x68, 0x2E,
            0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x3A, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4F,
            0x62, 0x6A, 0x65, 0x63, 0x74, 0x43, 0x6F, 0x6E, 0x74, 0x61, 0x69, 0x6E, 0x65, 0x72, 0x1F, 0x66,
            0x6C, 0x61, 0x73, 0x68, 0x2E, 0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x3A, 0x49, 0x6E, 0x74,
            0x65, 0x72, 0x61, 0x63, 0x74, 0x69, 0x76, 0x65, 0x4F, 0x62, 0x6A, 0x65, 0x63, 0x74, 0x1B, 0x66,
            0x6C, 0x61, 0x73, 0x68, 0x2E, 0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x3A, 0x44, 0x69, 0x73,
            0x70, 0x6C, 0x61, 0x79, 0x4F, 0x62, 0x6A, 0x65, 0x63, 0x74, 0x1C, 0x66, 0x6C, 0x61, 0x73, 0x68,
            0x2E, 0x65, 0x76, 0x65, 0x6E, 0x74, 0x73, 0x3A, 0x45, 0x76, 0x65, 0x6E, 0x74, 0x44, 0x69, 0x73,
            0x70, 0x61, 0x74, 0x63, 0x68, 0x65, 0x72, 0x04, 0x73, 0x74, 0x6F, 0x70, 0x0E, 0x61, 0x64, 0x64,
            0x46, 0x72, 0x61, 0x6D, 0x65, 0x53, 0x63, 0x72, 0x69, 0x70, 0x74, 0x06, 0x4F, 0x62, 0x6A, 0x65,
            0x63, 0x74, 0x0F, 0x45, 0x76, 0x65, 0x6E, 0x74, 0x44, 0x69, 0x73, 0x70, 0x61, 0x74, 0x63, 0x68,
            0x65, 0x72, 0x0D, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4F, 0x62, 0x6A, 0x65, 0x63, 0x74,
            0x11, 0x49, 0x6E, 0x74, 0x65, 0x72, 0x61, 0x63, 0x74, 0x69, 0x76, 0x65, 0x4F, 0x62, 0x6A, 0x65,
            0x63, 0x74, 0x16, 0x44, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4F, 0x62, 0x6A, 0x65, 0x63, 0x74,
            0x43, 0x6F, 0x6E, 0x74, 0x61, 0x69, 0x6E, 0x65, 0x72, 0x06, 0x53, 0x70, 0x72, 0x69, 0x74, 0x65,
            0x27, 0x16, 0x01, 0x16, 0x03, 0x18, 0x05, 0x16, 0x06, 0x17, 0x01, 0x05, 0x00, 0x05, 0x00, 0x08,
            0x0E, 0x08, 0x0F, 0x16, 0x10, 0x08, 0x11, 0x16, 0x12, 0x16, 0x13, 0x08, 0x14, 0x16, 0x15, 0x16,
            0x16, 0x08, 0x17, 0x16, 0x18, 0x16, 0x19, 0x16, 0x1A, 0x08, 0x1B, 0x08, 0x1C, 0x08, 0x1D, 0x08,
            0x1E, 0x16, 0x1F, 0x16, 0x20, 0x16, 0x21, 0x08, 0x22, 0x16, 0x23, 0x16, 0x24, 0x08, 0x25, 0x1A,
            0x05, 0x1A, 0x26, 0x1A, 0x27, 0x1A, 0x28, 0x1A, 0x29, 0x1A, 0x2A, 0x1A, 0x2B, 0x02, 0x26, 0x06,
            0x07, 0x04, 0x01, 0x05, 0x08, 0x09, 0x0A, 0x0B, 0x02, 0x0C, 0x0D, 0x0E, 0x0F, 0x10, 0x11, 0x12,
            0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F, 0x03, 0x20, 0x21,
            0x22, 0x23, 0x24, 0x25, 0x26, 0x17, 0x07, 0x01, 0x02, 0x07, 0x02, 0x04, 0x07, 0x04, 0x07, 0x07,
            0x05, 0x08, 0x07, 0x05, 0x09, 0x07, 0x05, 0x0A, 0x07, 0x05, 0x0B, 0x07, 0x05, 0x0C, 0x09, 0x0D,
            0x01, 0x09, 0x2C, 0x01, 0x09, 0x2D, 0x01, 0x09, 0x08, 0x01, 0x09, 0x09, 0x01, 0x09, 0x0A, 0x01,
            0x09, 0x0B, 0x01, 0x09, 0x0C, 0x01, 0x07, 0x04, 0x2E, 0x07, 0x0D, 0x2F, 0x07, 0x02, 0x30, 0x07,
            0x02, 0x31, 0x07, 0x02, 0x32, 0x07, 0x02, 0x33, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x02, 0x08, 0x03, 0x00,
            0x06, 0x06, 0x03, 0x00, 0x00, 0x02, 0x00, 0x04, 0x01, 0x00, 0x01, 0x05, 0x01, 0x00, 0x02, 0x06,
            0x01, 0x00, 0x03, 0x07, 0x01, 0x00, 0x04, 0x08, 0x01, 0x00, 0x05, 0x00, 0x00, 0x01, 0x07, 0x01,
            0x01, 0x04, 0x01, 0x00, 0x08, 0x00, 0x01, 0x01, 0x09, 0x0A, 0x03, 0xD0, 0x30, 0x47, 0x00, 0x00,
            0x01, 0x02, 0x01, 0x0A, 0x0B, 0x0C, 0xD0, 0x30, 0xD0, 0x27, 0x61, 0x09, 0x5D, 0x0A, 0x4F, 0x0A,
            0x00, 0x47, 0x00, 0x00, 0x02, 0x01, 0x01, 0x0A, 0x0B, 0x08, 0xD0, 0x30, 0x5D, 0x0A, 0x4F, 0x0A,
            0x00, 0x47, 0x00, 0x00, 0x03, 0x01, 0x01, 0x0A, 0x0B, 0x08, 0xD0, 0x30, 0x5D, 0x0A, 0x4F, 0x0A,
            0x00, 0x47, 0x00, 0x00, 0x04, 0x01, 0x01, 0x0A, 0x0B, 0x08, 0xD0, 0x30, 0x5D, 0x0A, 0x4F, 0x0A,
            0x00, 0x47, 0x00, 0x00, 0x05, 0x01, 0x01, 0x0A, 0x0B, 0x08, 0xD0, 0x30, 0x5D, 0x0A, 0x4F, 0x0A,
            0x00, 0x47, 0x00, 0x00, 0x06, 0x0B, 0x01, 0x0A, 0x0B, 0x24, 0xD0, 0x30, 0xD0, 0x49, 0x00, 0x5D,
            0x0B, 0x24, 0x00, 0xD0, 0x66, 0x0C, 0x24, 0x0B, 0xD0, 0x66, 0x0D, 0x24, 0x15, 0xD0, 0x66, 0x0E,
            0x24, 0x1F, 0xD0, 0x66, 0x0F, 0x24, 0x2A, 0xD0, 0x66, 0x10, 0x4F, 0x0B, 0x0A, 0x47, 0x00, 0x00,
            0x07, 0x02, 0x01, 0x01, 0x09, 0x27, 0xD0, 0x30, 0x65, 0x00, 0x60, 0x11, 0x30, 0x60, 0x12, 0x30,
            0x60, 0x13, 0x30, 0x60, 0x14, 0x30, 0x60, 0x15, 0x30, 0x60, 0x16, 0x30, 0x60, 0x02, 0x30, 0x60,
            0x02, 0x58, 0x00, 0x1D, 0x1D, 0x1D, 0x1D, 0x1D, 0x1D, 0x1D, 0x68, 0x01, 0x47, 0x00, 0x00
        };

        /// <summary>
        /// ResourceModFile objects that contain the hard-coded mod that disables multiplayer
        /// </summary>
        public static List<ResourceModFile> MultiplayerDisablerMod = new List<ResourceModFile>()
        {
            new ResourceModFile(s_parentMod, "generated/decls/menuelement/main_menu/screens/multiplayer.decl", "gameresources_patch2", false)
            {
                FileData = new MemoryStream(new byte[]
                {
                    0x7B, 0x65, 0x64, 0x69, 0x74, 0x3D, 0x7B, 0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4E, 0x61,
                    0x6D, 0x65, 0x3D, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D, 0x61,
                    0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x70, 0x6C, 0x61, 0x79, 0x5F, 0x6F, 0x6E, 0x6C, 0x69,
                    0x6E, 0x65, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x3B, 0x7D, 0x7D
                })
            },
            new ResourceModFile(s_parentMod, "generated/decls/menuelement/main_menu/screens/battle_arena_play_online.decl", "gameresources_patch2", false)
            {
                FileData = new MemoryStream(new byte[]
                {
                    0x7B, 0x65, 0x64, 0x69, 0x74, 0x3D, 0x7B, 0x64, 0x69, 0x73, 0x70, 0x6C, 0x61, 0x79, 0x4E, 0x61,
                    0x6D, 0x65, 0x3D, 0x22, 0x23, 0x73, 0x74, 0x72, 0x5F, 0x63, 0x6F, 0x64, 0x65, 0x5F, 0x6D, 0x61,
                    0x69, 0x6E, 0x6D, 0x65, 0x6E, 0x75, 0x5F, 0x62, 0x61, 0x74, 0x74, 0x6C, 0x65, 0x5F, 0x61, 0x72,
                    0x65, 0x6E, 0x61, 0x5F, 0x6E, 0x61, 0x6D, 0x65, 0x22, 0x3B, 0x7D, 0x7D
                })
            },
            new ResourceModFile(s_parentMod, "swf/hud/menus/battle_arena/play_online_screen.swf", "gameresources_patch1", false)
            {
                FileData = new MemoryStream(s_genericSWFData, 0, s_genericSWFData.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "swf/hud/menus/battle_arena/lobby.swf", "gameresources_patch1", false)
            {
                FileData = new MemoryStream(s_genericSWFData, 0, s_genericSWFData.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "swf/main_menu/screens/battle_arena.swf", "gameresources_patch2", false)
            {
                FileData = new MemoryStream(s_genericSWFData, 0, s_genericSWFData.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "swf/main_menu/screens/match_browser.swf", "gameresources_patch2", false)
            {
                FileData = new MemoryStream(s_genericSWFData, 0, s_genericSWFData.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/english.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledEnglish, 0, s_blangJsonMultiplayerDisabledEnglish.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/french.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledFrench, 0, s_blangJsonMultiplayerDisabledFrench.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/german.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledGerman, 0, s_blangJsonMultiplayerDisabledGerman.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/italian.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledItalian, 0, s_blangJsonMultiplayerDisabledItalian.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/japanese.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledJapanese, 0, s_blangJsonMultiplayerDisabledJapanese.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/korean.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledKorean, 0, s_blangJsonMultiplayerDisabledKorean.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/latin_spanish.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledSpanish, 0, s_blangJsonMultiplayerDisabledSpanish.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/polish.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledPolish, 0, s_blangJsonMultiplayerDisabledPolish.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/portuguese.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledPortuguese, 0, s_blangJsonMultiplayerDisabledPortuguese.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/russian.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledRussian, 0, s_blangJsonMultiplayerDisabledRussian.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/simplified_chinese.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledSimplifiedChinese, 0, s_blangJsonMultiplayerDisabledSimplifiedChinese.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/spanish.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledSpanish, 0, s_blangJsonMultiplayerDisabledSpanish.Length, false, true)
            },
            new ResourceModFile(s_parentMod, "EternalMod/strings/traditional_chinese.json", "gameresources_patch1", false)
            {
                IsBlangJson = true,
                FileData = new MemoryStream(s_blangJsonMultiplayerDisabledTraditionalChinese, 0, s_blangJsonMultiplayerDisabledTraditionalChinese.Length, false, true)
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
            "warehouseofflinecontainer",
            "tooltip",
            "livetile",
            "tutorialevent"
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
            "/impacteffect/",
            "/uiweapon/",
            "/globalinitialwarehouse/",
            "/globalshell/",
            "/warehouseitem/",
            "/warehouseofflinecontainer/",
            "/tooltip/",
            "/livetile/",
            "/tutorialevent/",
            "/maps/game/dlc/",
            "/maps/game/dlc2/",
            "/maps/game/hub/",
            "/maps/game/shell/",
            "/maps/game/sp/",
            "/maps/game/tutorials/",
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
                        if (!string.IsNullOrEmpty(mod.ResourceName)
                            && mod.ResourceName.StartsWith("pvp", StringComparison.OrdinalIgnoreCase))
                        {
                            return false;
                        }

                        foreach (var asset in mod.AssetsInfo.Assets)
                        {
                            if (string.IsNullOrEmpty(asset.MapResourceType))
                            {
                                continue;
                            }

                            if (!OnlineSafeMapResourceTypes.Contains(asset.MapResourceType.Trim().ToLowerInvariant()))
                            {
                                return false;
                            }
                        }
                    }

                    // Don't allow adding resources to the multiplayer maps
                    if (mod.AssetsInfo.Resources != null
                        && !string.IsNullOrEmpty(mod.ResourceName)
                        && mod.ResourceName.StartsWith("pvp", StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }

            // Allow modification of anything outside "generated/decls/"
            if (!string.IsNullOrEmpty(mod.Name)
                && !mod.Name.StartsWith("generated/decls/", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return OnlineSafeModNameKeywords.Any(keyword => mod.Name.Contains(keyword));
        }
    }
}
