using System.Globalization;
using System.Net;
using System.IO;
using System.Text.Json;

class Support{
    public static int GetUserInputInteger(string Prompt, Boolean noNewLine=false)
    {
        int rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                string jahUserInputStr = Console.ReadLine();
                rvalue = int.Parse(jahUserInputStr);
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return rvalue;
    }

    public static float GetUserInputFloat(string Prompt, Boolean noNewLine=false)
    {
        float rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                string jahUserInputStr = Console.ReadLine();
                rvalue = float.Parse(jahUserInputStr);
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return rvalue;
    }

    public static string GetUserInputString(string Prompt, Boolean noNewLine=false)
    {
        string jahUserInputStr = "";
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                jahUserInputStr = Console.ReadLine();
                if (string.IsNullOrEmpty(jahUserInputStr) == true)
                {
                    throw new Exception();
                }
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return jahUserInputStr;
    }

    public static float GetUserInputRealNumber(string Prompt, Boolean noNewLine=false)
    {
        float rvalue = 0;
        bool jahFlag = true;
        while (jahFlag)
        {
            try
            {
                Display(Prompt, noNewLine);
                string jahUserInputStr = Console.ReadLine();
                rvalue = float.Parse(jahUserInputStr);
                if (float.IsRealNumber(rvalue))
                {
                    throw new Exception();
                }
                jahFlag = false;
            } catch (Exception)
            {
                Display("Value is not acceptable, please try again.", noNewLine);
            }
        }

        return rvalue;
    }
    public static void GetEmptyInput()
    {
        Console.ReadLine();
    }
    public static void Display(string s)
    {
        Console.WriteLine(s);
    }
    public static void Display(string s, Boolean noNewLine)
    {
        if (noNewLine){
            Console.Write(s);
        }
        else
        {
            Console.WriteLine(s);
        }
    }

    public static void Clear()
    {
        Console.Clear();
    }

    public static string GetRandomString(List<string> stringList)
    {
        if (stringList.Count == 0)
        {
            return "ERROR: EMPTY LIST";
        }

        string rvalue = stringList[GetRandomInt(stringList.Count)];

        return rvalue;
    }
    public static int GetRandomInt(int length)
    {
        Random random = new Random();
        int index = random.Next(length);

        return index;
    }
    public static string FormatStringToFile(string target, string issue=",", string replace="~~||~~")
    {
        return target.Replace(issue, replace);
    }
    public static Dictionary<string, Object> FormatDictToFile(Dictionary<string, Object> dict)
    {
        foreach (string key in dict.Keys)
        {
            dict[key] = FormatToFile(dict[key]);
        }
        return dict;
    }
    public static List<Object> FormatListToFile(List<Object> target)
    {
        List<Object> newList = new();
        foreach(Object piece in target)
        {
            newList.Add(FormatToFile(piece));
        }

        return newList;
    }
    public static Object FormatToFile(Object target)
    {
        if (target is string)
        {
            return FormatStringToFile((string)target);
        } else if (target is List<Object>)
        {
            return FormatListToFile((List<Object>)target);
        } else if (target is Dictionary<string, Object>)
        {
            return FormatDictToFile((Dictionary<string, Object>)target);
        }

        return target;
    }
    public static string JsonToString(Object dict)
    {
        dict = FormatToFile(dict);
        return JsonSerializer.Serialize(dict);
    }


    public static string FormatFileToString(string target, string replace=",", string issue="~~||~~")
    {
        return target.Replace(issue, replace);
    }
    public static Dictionary<string, Object> FormatFileToDict(Dictionary<string, Object> dict)
    {
        foreach (string key in dict.Keys)
        {
            dict[key] = FormatFromFile(dict[key]);
        }
        return dict;
    }
    public static List<Object> FormatFileToList(List<Object> target)
    {
        List<Object> newList = new();
        foreach(Object piece in target)
        {
            newList.Add(FormatFromFile(piece));
        }

        return newList;
    }
    public static Object FormatFromFile(Object target)
    {
        if (target is string)
        {
            return FormatFileToString((string)target);
        } else if (target is List<Object>)
        {
            return FormatFileToList((List<Object>)target);
        } else if (target is Dictionary<string, Object>)
        {
            return FormatFileToDict((Dictionary<string, Object>)target);
        }

        return target;
    }
    public static Dictionary<string, Object> StringToJson(string content)
    {
        Dictionary<string, JsonElement> dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(content);
        Dictionary<string, Object> result = new();

        foreach (var kvp in dict)
        {
            result[kvp.Key] = JsonLoad(kvp.Value);
        }

        result = FormatFileToDict(result);

        return result;
    }
    public static Object JsonLoadNum(Object target)
    {
        try
        {
            return ((JsonElement)target).GetInt32();
        } catch
        {
            return ((JsonElement)target).GetDouble();
        }
    }
    public static string JsonLoadString(Object target)
    {
        return ((JsonElement)target).GetString();
    }
    public static Object JsonLoad(Object target)
    {
        JsonElement element = (JsonElement)target;

        switch (element.ValueKind)
        {
            case JsonValueKind.Number:
                return JsonLoadNum(element);

            case JsonValueKind.String:
                return JsonLoadString(element);

            case JsonValueKind.Array:
                return JsonLoadList(element);

            case JsonValueKind.Object:
                return JsonLoadDict(element);
        }

        return null;
    }
    public static List<Object> JsonLoadList(Object target)
    {
        JsonElement array = (JsonElement)target;

        List<Object> newList = new();

        foreach (JsonElement piece in array.EnumerateArray())
        {
            newList.Add(JsonLoad(piece));
        }

        return newList;
    }
    public static Dictionary<string, Object> JsonLoadDict(Object target)
    {
        JsonElement dict = (JsonElement)target;
        Dictionary<string, Object> newDict = new();

        foreach (JsonProperty prop in dict.EnumerateObject())
        {
            newDict[prop.Name] = JsonLoad(prop.Value);
        }

        return newDict;
    }

    public static void SaveAsFile(string content, string fileName, string fileType="txt")
    {
        File.WriteAllText($"{fileName}.{fileType}", content);
    }
    public static void SaveAsFile(Dictionary<string, Object> content, string fileName, string fileType="txt")
    {
        File.WriteAllText($"{fileName}.{fileType}", JsonToString(content));
    }
    
    public static void SaveFile(string content, string fileName, string fileType="txt")
    {
        File.AppendAllText($"{fileName}.{fileType}", $"\n{content}");
    }

    public static string LoadFile(string fileName, string fileType="txt")
    {
        return File.ReadAllText($"{fileName}.{fileType}");
    }
    public static Dictionary<string, Object> LoadDictFile(string fileName, string fileType="txt")
    {
        string file = File.ReadAllText($"{fileName}.{fileType}");
        return StringToJson(file);
    }

    public static Boolean StringIsIn(string target, List<string> recipient)
    {
        foreach(string suspect in recipient)
        {
            if(suspect == target)
            {
                return true;
            }
        }

        return false;
    }
    public static Boolean StringIsIn<TValue>(string target, Dictionary<string, TValue> recipient)
    {
        foreach(string suspect in recipient.Keys)
        {
            if(suspect == target)
            {
                return true;
            }
        }
        
        return false;
    }
    public static Boolean StringIsIn<T>(string target, Dictionary<string, List<T>> recipient)
    {
        foreach(string suspect in recipient.Keys)
        {
            if(suspect == target)
            {
                return true;
            }
        }
        
        return false;
    }

    public static Dictionary<string, List<T>> StoreData<T>(T data, string storageKey, Dictionary<string, List<T>> storage)
    {
        if(StringIsIn(storageKey, storage))
        {
            storage[storageKey].Add(data);
        }
        else
        {
            List<T> dataList = new List<T>();
            dataList.Add(data);
            storage[storageKey] = dataList;
        }

        return storage;
    }
    public static List<T> LoadData<T>(string storageKey, Dictionary<string, List<T>> storage)
    {
        return storage[storageKey];
    }
}