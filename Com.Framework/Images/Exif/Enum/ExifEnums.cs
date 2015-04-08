/*************************************************
Author: Leo Shao      
Generated Date: 2015-03-01
Project: 公用框架
Version: 1.0   
.Net Version: 3.5
Description:    // 模块功能描述（如功能、主要算法、内部各部分之间的关系、该文件与其它文件关系等）
Others:         // 其它内容的说明
History:        // 修改历史记录列表，每条修改记录应包括修改日期、修改者及修改内容简述
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Framework.Images.Exif.Enum
{
    public enum Compression : ushort
    {
        Uncompressed = 1,
        JPEGCompression = 6,
    }

    public enum PhotometricInterpretation : ushort
    {
        RGB = 2,
        YCbCr = 6,
    }

    public enum Orientation : ushort
    {
        Normal = 1,
        MirroredVertically = 2,
        Rotated180 = 3,
        MirroredHorizontally = 4,
        RotatedLeftAndMirroredVertically = 5,
        RotatedRight = 6,
        RotatedLeft = 7,
        RotatedRightAndMirroredVertically = 8,
    }

    public enum PlanarConfiguration : ushort
    {
        ChunkyFormat = 1,
        PlanarFormat = 2,
    }

    public enum YCbCrPositioning : ushort
    {
        Centered = 1,
        CoSited = 2,
    }

    public enum ResolutionUnit : ushort
    {
        Inches = 2,
        Centimeters = 3,
    }

    public enum ColorSpace : ushort
    {
        sRGB = 1,
        Uncalibrated = 0xfff,
    }

    public enum ExposureProgram : ushort
    {
        NotDefined = 0,
        Manual = 1,
        Normal = 2,
        AperturePriority = 3,
        ShutterPriority = 4,
        /// <summary>
        /// Biased toward depth of field.
        /// </summary>
        Creative = 5,
        /// <summary>
        /// Biased toward fast shutter speed.
        /// </summary>
        Action = 6,
        /// <summary>
        /// For closeup photos with the background out of focus.
        /// </summary>
        Portrait = 7,
        /// <summary>
        /// For landscape photos with the background in focus.
        /// </summary>
        Landscape = 8,
    }

    public enum MeteringMode : ushort
    {
        Unknown = 0,
        Average = 1,
        CenterWeightedAverage = 2,
        Spot = 3,
        MultiSpot = 4,
        Pattern = 5,
        Partial = 6,
        Other = 255,
    }

    public enum LightSource : ushort
    {
        Unknown = 0,
        Daylight = 1,
        Fluorescent = 2,
        Tungsten = 3,
        Flash = 4,
        FineWeather = 9,
        CloudyWeather = 10,
        Shade = 11,
        /// <summary>
        /// D 5700 – 7100K
        /// </summary>
        DaylightFluorescent = 12,
        /// <summary>
        /// N 4600 – 5400K
        /// </summary>
        DayWhiteFluorescent = 13,
        /// <summary>
        /// W 3900 – 4500K
        /// </summary>
        CoolWhiteFluorescent = 14,
        /// <summary>
        /// WW 3200 – 3700K
        /// </summary>
        WhiteFluorescent = 15,
        StandardLightA = 17,
        StandardLightB = 18,
        StandardLightC = 19,
        D55 = 20,
        D65 = 21,
        D75 = 22,
        D50 = 23,
        ISOStudioTungsten = 24,
        OtherLightSource = 255,
    }

    [Flags]
    public enum Flash : ushort
    {
        FlashDidNotFire = 0,
        StrobeReturnLightNotDetected = 4,
        StrobeReturnLightDetected = 2,
        FlashFired = 1,
        CompulsoryFlashMode = 8,
        AutoMode = 16,
        NoFlashFunction = 32,
        RedEyeReductionMode = 64,
    }

    public enum SensingMethod : ushort
    {
        NotDefined = 1,
        OneChipColorAreaSensor = 2,
        TwoChipColorAreaSensor = 3,
        ThreeChipColorAreaSensor = 4,
        ColorSequentialAreaSensor = 5,
        TriLinearSensor = 7,
        ColorSequentialLinearSensor = 8,
    }

    public enum FileSource : byte // UNDEFINED
    {
        DSC = 3,
    }

    public enum SceneType : byte // UNDEFINED
    {
        DirectlyPhotographedImage = 1,
    }

    public enum CustomRendered : ushort
    {
        NormalProcess = 0,
        CustomProcess = 1,
    }

    public enum ExposureMode : ushort
    {
        Auto = 0,
        Manual = 1,
        AutoBracket = 2,
    }

    public enum WhiteBalance : ushort
    {
        Auto = 0,
        Manual = 1,
    }

    public enum SceneCaptureType : ushort
    {
        Standard = 0,
        Landscape = 1,
        Portrait = 2,
        NightScene = 3,
    }

    public enum GainControl : ushort
    {
        None = 0,
        LowGainUp = 1,
        HighGainUp = 2,
        LowGainDown = 3,
        HighGainDown = 4,
    }

    public enum Contrast : ushort
    {
        Normal = 0,
        Soft = 1,
        Hard = 2,
    }

    public enum Saturation : ushort
    {
        Normal = 0,
        Low = 1,
        High = 2,
    }

    public enum Sharpness : ushort
    {
        Normal = 0,
        Soft = 1,
        Hard = 2,
    }

    public enum SubjectDistanceRange : ushort
    {
        Unknown = 0,
        Macro = 1,
        CloseView = 2,
        DistantView = 3,
    }

    public enum GPSLatitudeRef : byte // ASCII
    {
        North = 78, // 'N'
        South = 83, // 'S'
    }

    public enum GPSLongitudeRef : byte // ASCII
    {
        West = 87, // 'W'
        East = 69, // 'E'
    }

    public enum GPSAltitudeRef : byte
    {
        AboveSeaLevel = 0,
        BelowSeaLevel = 1,
    }

    public enum GPSStatus : byte // ASCII
    {
        MeasurementInProgress = 65, // 'A'
        MeasurementInteroperability = 86, // 'V'
    }

    public enum GPSMeasureMode : byte // ASCII
    {
        TwoDimensional = 50, // '2'
        ThreeDimensional = 51, // '3'
    }

    public enum GPSSpeedRef : byte // ASCII
    {
        KilometersPerHour = 75, // 'K'
        MilesPerHour = 77, // 'M'
        Knots = 78, // 'N'
    }

    public enum GPSDirectionRef : byte // ASCII
    {
        TrueDirection = 84, // 'T'
        MagneticDirection = 77, // 'M'
    }

    public enum GPSDistanceRef : byte // ASCII
    {
        Kilometers = 75, // 'K'
        Miles = 77, // 'M'
        Knots = 78, // 'N'
    }

    public enum GPSDifferential : ushort
    {
        MeasurementWithoutDifferentialCorrection = 0,
        DifferentialCorrectionApplied = 1,
    }
}

