using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using RootStats.Controllers;
using RootStats.UI;
using RootStats.UI.Theme;
using RootStats.UI.Views;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    [SerializeField] private TextExtension _title;
    [SerializeField] private View _header;
    [SerializeField] private View _main;
    [SerializeField] private View _footer;

    private void Awake()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        ThemeManager.Init();

        _title.Init();
        _header.Init();
        _main.Init();
        _footer.Init();

        var controllers = GameObject.FindObjectsOfType<Controller>();

        foreach (var controller in controllers)
        {
            StartCoroutine(controller.Init());

            while (!controller.IsInitialized)
            {
                yield return null;
                Debug.Log(controller.GetType());
            }

            if (controller.GetType() == typeof(HomeController))
                controller.ShowWindow();
            else
                controller.HideWindow();
        }
    }
}

//TODO: Скорее всего не пригодится, но решение стоит куда-то сохранить!
public static class OpenGenericTypeFinders
{
    private static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
    {
        return from x in assembly.GetTypes()
            let y = x.BaseType
            where
                (y != null && y.IsGenericType &&
                 openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition()))
            select x;
    }
}