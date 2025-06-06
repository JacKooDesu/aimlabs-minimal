/*
 * Tencent is pleased to support the open source community by making InjectFix available.
 * Copyright (C) 2019 THL A29 Limited, a Tencent company.  All rights reserved.
 * InjectFix is licensed under the MIT License, except for the third-party components listed in the file 'LICENSE' which may be subject to their corresponding license terms. 
 * This file is subject to the terms and conditions defined in file 'LICENSE', which is part of this source code package.
 */

using System.Collections.Generic;
using Puerts;
using System;
using UnityEngine;

//1、配置类必须打[Configure]标签
//2、必须放Editor目录
[Configure]
public class TypeConfig
{
    [Binding]
    static IEnumerable<Type> Bindings
    {
        get
        {
            return new List<Type>()
            {
                typeof(UnityEngine.Application),
                typeof(Debug),
                typeof(Vector3),
                typeof(System.Array),
                typeof(List<int>),
                typeof(Dictionary<string, List<int>>),
                typeof(Time),
                typeof(Transform),
                typeof(Component),
                typeof(GameObject),
                typeof(UnityEngine.Object),
                typeof(Delegate),
                typeof(System.Object),
                typeof(Type),
                typeof(ParticleSystem),
                typeof(Canvas),
                typeof(RenderMode),
                typeof(Behaviour),
                typeof(MonoBehaviour),
                typeof(System.IO.File),
                typeof(System.IO.Path),
                typeof(System.IO.Directory),
                typeof(System.Action<,>),
                typeof(System.Linq.IQueryable<>),

                typeof(UnityEngine.Networking.UnityWebRequest),
                typeof(UnityEngine.Networking.DownloadHandler),
                typeof(UnityEngine.EventSystems.UIBehaviour),
                typeof(UnityEngine.UI.Selectable),
                typeof(UnityEngine.UI.Button),
                typeof(UnityEngine.UI.Button.ButtonClickedEvent),
                typeof(UnityEngine.Events.UnityEvent),
                typeof(UnityEngine.UI.InputField),
                typeof(UnityEngine.UI.Toggle),
                typeof(UnityEngine.UI.Toggle.ToggleEvent),
                typeof(UnityEngine.Events.UnityEvent<bool>),
                typeof(UnityEngine.Color),

                // UI Toolkit
                typeof(UnityEngine.UIElements.Toggle),
                typeof(UnityEngine.UIElements.SliderInt),
                typeof(UnityEngine.UIElements.FloatField),
                typeof(UnityEngine.UIElements.TextField),
                typeof(UnityEngine.UIElements.IntegerField),

                typeof(Realms.Realm),
                typeof(Realms.Realm.Dynamic),
                typeof(Realms.DynamicObjectApi),
                typeof(Realms.Migration),
                typeof(Realms.IRealmObjectBase),
                typeof(Realms.IRealmObject),

                // ALM Domain
                typeof(ALM.Screens.Mission.JsConfigure),
                typeof(ALM.Screens.Mission.JsConfigureDel),
                typeof(ALM.Screens.Mission.BallPoolService),
                typeof(ALM.Screens.Mission.RaycasterService),
                typeof(ALM.Screens.Mission.Time),
                typeof(ALM.Screens.Mission.IRaycaster),
                typeof(ALM.Screens.Mission.IRaycastTarget),
                typeof(ALM.Screens.Mission.AnomoyousRaycastTarget),
                typeof(ALM.Screens.Mission.Ball),
                typeof(ALM.Screens.Base.AudioService),
                typeof(ALM.Screens.Mission.ScoreService),
                typeof(ALM.Screens.Mission.IScoreCalculator),
                typeof(ALM.Screens.Mission.JsScoreCalculator),
                typeof(ALM.Screens.Base.CrosshairPanel.OptionSetting),
                typeof(ALM.Screens.Mission.GltfLoaderService),

                // ALM Datas
                typeof(ALM.Data.MissionData),
                typeof(ALM.Data.MissionScoreData),
                typeof(ALM.Data.PlayHistory),

                // ALM Util
                typeof(ALM.Util.FileIO),
                typeof(ALM.Util.UIToolkitExtend.DataBinderCS),
                typeof(ALM.Util.UIToolkitExtend.Bindable),
                typeof(ALM.Util.UIToolkitExtend.OriginBindalbe.Toggle),
                typeof(ALM.Util.UIToolkitExtend.OriginBindalbe.Slider),
                typeof(ALM.Util.UIToolkitExtend.OriginBindalbe.SliderInt),
                typeof(ALM.Util.UIToolkitExtend.Elements.ColorBindElement),
                typeof(ALM.Util.UIToolkitExtend.Elements.ColorBindElement.RgbaBindable),
                typeof(ALM.Util.UIToolkitExtend.Elements.ColorBindElement.RgbBindable),
                typeof(ALM.Util.RealmWrapper),
                typeof(ALM.Util.Texturing.Creator),
                typeof(ALM.Util.Texturing.Drawer),
                typeof(ALM.Util.Rng),
                typeof(ALM.Util.EventBinder.CollideBasedHandler),
                typeof(ALM.Util.EventBinder.CollisionEventHandler),
                typeof(ALM.Util.EventBinder.TriggerEventHandler),
            };
        }
    }

    [BlittableCopy]
    static IEnumerable<Type> Blittables
    {
        get
        {
            return new List<Type>()
            {
                //打开这个可以优化Vector3的GC，但需要开启unsafe编译
                //typeof(Vector3),
            };
        }
    }

    [Filter]
    static bool FilterMethods(System.Reflection.MemberInfo mb)
    {
        // 排除 MonoBehaviour.runInEditMode, 在 Editor 环境下可用发布后不存在
        if (mb.DeclaringType == typeof(MonoBehaviour) && mb.Name == "runInEditMode")
        {
            return true;
        }
        if (mb.DeclaringType == typeof(Type) && (mb.Name == "MakeGenericSignatureType" || mb.Name == "IsCollectible"))
        {
            return true;
        }
        if (mb.DeclaringType == typeof(System.IO.File))
        {
            if (mb.Name == "SetAccessControl" || mb.Name == "GetAccessControl")
            {
                return true;

            }
            else if (mb.Name == "Create")
            {
                return true;
            }
        }
        return false;
    }
}