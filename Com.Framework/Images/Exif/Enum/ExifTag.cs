﻿/*************************************************
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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Com.Framework.Images.Exif.Enum
{
    /// <summary>
    /// 代表与EXIF领域相关的标签
    /// </summary>
    public enum ExifTag : int
    {
        // ****************************
        // TIFF Tags
        // ****************************
        ImageWidth = IFD.Zeroth + 256,
        ImageLength = IFD.Zeroth + 257,
        BitsPerSample = IFD.Zeroth + 258,
        Compression = IFD.Zeroth + 259,
        PhotometricInterpretation = IFD.Zeroth + 262,
        Orientation = IFD.Zeroth + 274,
        SamplesPerPixel = IFD.Zeroth + 277,
        PlanarConfiguration = IFD.Zeroth + 284,
        YCbCrSubSampling = IFD.Zeroth + 530,
        YCbCrPositioning = IFD.Zeroth + 531,
        XResolution = IFD.Zeroth + 282,
        YResolution = IFD.Zeroth + 283,
        ResolutionUnit = IFD.Zeroth + 296,
        StripOffsets = IFD.Zeroth + 273,
        RowsPerStrip = IFD.Zeroth + 278,
        StripByteCounts = IFD.Zeroth + 279,
        JPEGInterchangeFormat = IFD.Zeroth + 513,
        JPEGInterchangeFormatLength = IFD.Zeroth + 514,
        TransferFunction = IFD.Zeroth + 301,
        WhitePoint = IFD.Zeroth + 318,
        PrimaryChromaticities = IFD.Zeroth + 319,
        YCbCrCoefficients = IFD.Zeroth + 529,
        ReferenceBlackWhite = IFD.Zeroth + 532,
        /// <summary>
        /// 图像最后一次被修改时的日期/时间. 日期的格式是 "YYYY:MM:DD HH:MM:SS"+0x00, 一共 20个字节. 
        /// 如果没有设置时钟或者数字相机没有时钟, 则这个域是用空格来填充. 
        /// 通常, 它和DateTimeOriginal(0x9003)具有相同的值
        /// </summary>
        [Description("图像最后一次被修改时的日期/时间")]
        DateTime = IFD.Zeroth + 306,
        [Description("图像说明")]
        ImageDescription = IFD.Zeroth + 270,
        Make = IFD.Zeroth + 271,
        [Description("设备型号")]
        Model = IFD.Zeroth + 272,
        Software = IFD.Zeroth + 305,
        Artist = IFD.Zeroth + 315,
        Copyright = IFD.Zeroth + 33432,
        EXIFIFDPointer = IFD.Zeroth + 34665,
        GPSIFDPointer = IFD.Zeroth + 34853,
        // ****************************
        // EXIF Tags
        // ****************************
        ExifVersion = IFD.EXIF + 36864,
        FlashpixVersion = IFD.EXIF + 40960,
        ColorSpace = IFD.EXIF + 40961,
        ComponentsConfiguration = IFD.EXIF + 37121,
        CompressedBitsPerPixel = IFD.EXIF + 37122,
        PixelXDimension = IFD.EXIF + 40962,
        PixelYDimension = IFD.EXIF + 40963,
        MakerNote = IFD.EXIF + 37500,
        UserComment = IFD.EXIF + 37510,
        RelatedSoundFile = IFD.EXIF + 40964,
        /// <summary>
        /// 照片在被拍下来的日期/时间. 使用用户的软件是不能被修改这个值的. 日期的格式是 "YYYY:MM:DD HH:MM:SS"+0x00, 一共占用20个字节. 
        /// 如果数字相机没有设置时钟或者 数字相机没有时钟, 这个域使用空格来填充. 在Exif标准中, 这个标签是可选的, 但是在 DCF中是必需的
        /// </summary>
        [Description("照片在被拍下来的日期/时间")]
        DateTimeOriginal = IFD.EXIF + 36867,
        /// <summary>
        /// 照片被数字化时的日期/时间. 通常, 它与DateTimeOriginal(0x9003)具有相同的值. 数据格式是 "YYYY:MM:DD HH:MM:SS"+0x00, 一共占用20个字节. 
        /// 如果数字相机没有设置时钟或者 数字相机没有时钟, 这个域使用空格来填充. 在Exif标准中, 这个标签是可选的, 但是在 DCF中是必需的.
        /// </summary>
        [Description("照片被数字化时的日期/时间")]
        DateTimeDigitized = IFD.EXIF + 36868,
        SubSecTime = IFD.EXIF + 37520,
        SubSecTimeOriginal = IFD.EXIF + 37521,
        SubSecTimeDigitized = IFD.EXIF + 37522,
        [Description("曝光时间")]
        ExposureTime = IFD.EXIF + 33434,
        [Description("光圈值")]
        FNumber = IFD.EXIF + 33437,
        ExposureProgram = IFD.EXIF + 34850,
        SpectralSensitivity = IFD.EXIF + 34852,
        ISOSpeedRatings = IFD.EXIF + 34855,
        OECF = IFD.EXIF + 34856,
        ShutterSpeedValue = IFD.EXIF + 37377,
        ApertureValue = IFD.EXIF + 37378,
        BrightnessValue = IFD.EXIF + 37379,
        ExposureBiasValue = IFD.EXIF + 37380,
        MaxApertureValue = IFD.EXIF + 37381,
        SubjectDistance = IFD.EXIF + 37382,
        MeteringMode = IFD.EXIF + 37383,
        LightSource = IFD.EXIF + 37384,
        Flash = IFD.EXIF + 37385,
        [Description("焦距")]
        FocalLength = IFD.EXIF + 37386,
        SubjectArea = IFD.EXIF + 37396,
        FlashEnergy = IFD.EXIF + 41483,
        SpatialFrequencyResponse = IFD.EXIF + 41484,
        FocalPlaneXResolution = IFD.EXIF + 41486,
        FocalPlaneYResolution = IFD.EXIF + 41487,
        FocalPlaneResolutionUnit = IFD.EXIF + 41488,
        SubjectLocation = IFD.EXIF + 41492,
        ExposureIndex = IFD.EXIF + 41493,
        SensingMethod = IFD.EXIF + 41495,
        FileSource = IFD.EXIF + 41728,
        SceneType = IFD.EXIF + 41729,
        CFAPattern = IFD.EXIF + 41730,
        CustomRendered = IFD.EXIF + 41985,
        ExposureMode = IFD.EXIF + 41986,
        WhiteBalance = IFD.EXIF + 41987,
        DigitalZoomRatio = IFD.EXIF + 41988,
        FocalLengthIn35mmFilm = IFD.EXIF + 41989,
        SceneCaptureType = IFD.EXIF + 41990,
        GainControl = IFD.EXIF + 41991,
        Contrast = IFD.EXIF + 41992,
        Saturation = IFD.EXIF + 41993,
        Sharpness = IFD.EXIF + 41994,
        DeviceSettingDescription = IFD.EXIF + 41995,
        SubjectDistanceRange = IFD.EXIF + 41996,
        ImageUniqueID = IFD.EXIF + 42016,
        InteroperabilityIFDPointer = IFD.EXIF + 40965,
        // ****************************
        // GPS Tags
        // ****************************
        GPSVersionID = IFD.GPS + 0,
        GPSLatitudeRef = IFD.GPS + 1,
        GPSLatitude = IFD.GPS + 2,
        GPSLongitudeRef = IFD.GPS + 3,
        GPSLongitude = IFD.GPS + 4,
        GPSAltitudeRef = IFD.GPS + 5,
        GPSAltitude = IFD.GPS + 6,
        GPSTimeStamp = IFD.GPS + 7,
        GPSSatellites = IFD.GPS + 8,
        GPSStatus = IFD.GPS + 9,
        GPSMeasureMode = IFD.GPS + 10,
        GPSDOP = IFD.GPS + 11,
        GPSSpeedRef = IFD.GPS + 12,
        GPSSpeed = IFD.GPS + 13,
        GPSTrackRef = IFD.GPS + 14,
        GPSTrack = IFD.GPS + 15,
        GPSImgDirectionRef = IFD.GPS + 16,
        GPSImgDirection = IFD.GPS + 17,
        GPSMapDatum = IFD.GPS + 18,
        GPSDestLatitudeRef = IFD.GPS + 19,
        GPSDestLatitude = IFD.GPS + 20,
        GPSDestLongitudeRef = IFD.GPS + 21,
        GPSDestLongitude = IFD.GPS + 22,
        GPSDestBearingRef = IFD.GPS + 23,
        GPSDestBearing = IFD.GPS + 24,
        GPSDestDistanceRef = IFD.GPS + 25,
        GPSDestDistance = IFD.GPS + 26,
        GPSProcessingMethod = IFD.GPS + 27,
        GPSAreaInformation = IFD.GPS + 28,
        GPSDateStamp = IFD.GPS + 29,
        GPSDifferential = IFD.GPS + 30,
        // ****************************
        // InterOp Tags
        // ****************************
        InteroperabilityIndex = IFD.Interop + 1,
        InteroperabilityVersion = IFD.Interop + 2,
        // ****************************
        // First IFD TIFF Tags
        // ****************************
        ThumbnailImageWidth = IFD.First + 256,
        ThumbnailImageLength = IFD.First + 257,
        ThumbnailBitsPerSample = IFD.First + 258,
        ThumbnailCompression = IFD.First + 259,
        ThumbnailPhotometricInterpretation = IFD.First + 262,
        ThumbnailOrientation = IFD.First + 274,
        ThumbnailSamplesPerPixel = IFD.First + 277,
        ThumbnailPlanarConfiguration = IFD.First + 284,
        ThumbnailYCbCrSubSampling = IFD.First + 530,
        ThumbnailYCbCrPositioning = IFD.First + 531,
        ThumbnailXResolution = IFD.First + 282,
        ThumbnailYResolution = IFD.First + 283,
        ThumbnailResolutionUnit = IFD.First + 296,
        ThumbnailStripOffsets = IFD.First + 273,
        ThumbnailRowsPerStrip = IFD.First + 278,
        ThumbnailStripByteCounts = IFD.First + 279,
        ThumbnailJPEGInterchangeFormat = IFD.First + 513,
        ThumbnailJPEGInterchangeFormatLength = IFD.First + 514,
        ThumbnailTransferFunction = IFD.First + 301,
        ThumbnailWhitePoint = IFD.First + 318,
        ThumbnailPrimaryChromaticities = IFD.First + 319,
        ThumbnailYCbCrCoefficients = IFD.First + 529,
        ThumbnailReferenceBlackWhite = IFD.First + 532,
        ThumbnailDateTime = IFD.First + 306,
        ThumbnailImageDescription = IFD.First + 270,
        ThumbnailMake = IFD.First + 271,
        ThumbnailModel = IFD.First + 272,
        ThumbnailSoftware = IFD.First + 305,
        ThumbnailArtist = IFD.First + 315,
        ThumbnailCopyright = IFD.First + 33432,
    }

}
