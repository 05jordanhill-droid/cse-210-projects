using System.Globalization;
using System.Net;
using System.IO;
using System.Text.Json;
using System.ComponentModel;

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
    public static T GetRandom<T>(List<T> list)
    {
        Random random = new Random();
        T rvalue = list[GetRandomInt(list.Count)];

        return rvalue;
    }



    // Saving / Loading Files
    private static string FormatStringToFile(string target, string issue=",", string replace="~~||~~")
    {
        return target.Replace(issue, replace);
    }
    private static Dictionary<string, Object> FormatDictToFile(Dictionary<string, Object> dict)
    {
        foreach (string key in dict.Keys)
        {
            dict[key] = FormatToFile(dict[key]);
        }
        return dict;
    }
    private static List<Object> FormatListToFile(List<Object> target)
    {
        List<Object> newList = new();
        foreach(Object piece in target)
        {
            newList.Add(FormatToFile(piece));
        }

        return newList;
    }
    private static Object FormatToFile(Object target)
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
    private static string JsonToString(Object dict)
    {
        dict = FormatToFile(dict);
        return JsonSerializer.Serialize(dict);
    }
    private static string FormatFileToString(string target, string replace=",", string issue="~~||~~")
    {
        return target.Replace(issue, replace);
    }
    private static Dictionary<string, Object> FormatFileToDict(Dictionary<string, Object> dict)
    {
        foreach (string key in dict.Keys)
        {
            dict[key] = FormatFromFile(dict[key]);
        }
        return dict;
    }
    private static List<Object> FormatFileToList(List<Object> target)
    {
        List<Object> newList = new();
        foreach(Object piece in target)
        {
            newList.Add(FormatFromFile(piece));
        }

        return newList;
    }
    private static Object FormatFromFile(Object target)
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
    private static Dictionary<string, Object> StringToJson(string content)
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
    private static Object JsonLoadNum(Object target)
    {
        try
        {
            return ((JsonElement)target).GetInt32();
        } catch
        {
            return ((JsonElement)target).GetDouble();
        }
    }
    private static string JsonLoadString(Object target)
    {
        return ((JsonElement)target).GetString();
    }
    private static Object JsonLoad(Object target)
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
    private static List<Object> JsonLoadList(Object target)
    {
        JsonElement array = (JsonElement)target;

        List<Object> newList = new();

        foreach (JsonElement piece in array.EnumerateArray())
        {
            newList.Add(JsonLoad(piece));
        }

        return newList;
    }
    private static Dictionary<string, Object> JsonLoadDict(Object target)
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
// 
// String is in
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
// 
// Data Storage
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
// 
// Menu Interface

/*
    static List<Object> DictFunction(List<Object> Bundled)
    {
        //type1// var1 = (//type1//)Bundled[0];
        //...

        //Code to Execute

        Bundled = new(){
            //var1,
            //...
        };
        return Bundled;
    }
*/
    public static void RunMenu(List<string> keyList, List<Func<Object>> valueList, string choicePrompt=">", string quit="Quit", Boolean endless=false, string errorMessage="Invalid Choice. Try Again.")
    {
        if(quit == "Quit" && !endless && !valueList.Contains(EndMenuRun))
        {
            keyList.Add($"{valueList.Count + 1}. {quit}");
            valueList.Add(EndMenuRun);
        }

        Dictionary<string, Func<Object>> menuDict = IndexizeDict(keyList, valueList);
        Boolean run = true;

        while(run)
        {
            DisplayMenu(menuDict);
            
            string choice = GetUserInputString(choicePrompt, true);
            try
            {
                Object outcome = GetChoice(menuDict, choice);
                run = CheckChoiceEnd(outcome, run);
            }
            catch
            {
                Display(errorMessage);
            }
        }
    }
    public static void RunMenu(List<string> keyList, List<Func<Object, Object>> valueList, Object var, string choicePrompt=">", string quit="Quit", Boolean endless=false, string errorMessage="Invalid Choice. Try Again.")
    {
        if(quit == "Quit" && !endless && !valueList.Contains(EndMenuRun))
        {
            keyList.Add($"{valueList.Count + 1}. {quit}");
            valueList.Add(EndMenuRun);
        }

        Dictionary<string, Func<Object, Object>> menuDict = IndexizeDict(keyList, valueList);
        Boolean run = true;

        while(run)
        {
            DisplayMenu(menuDict);
            
            string choice = GetUserInputString(choicePrompt, true);
            try
            {
                Object outcome = GetChoice(menuDict, choice, var);
                run = CheckChoiceEnd(outcome, run);
            }
            catch
            {
                Display(errorMessage);
            }
        }
    }
    public static Boolean CheckChoiceEnd(Object outcome, Boolean run)
    {
        if(outcome is string)
        {
            if((string)outcome == "~~||~~ END MENU RUN ~~||~~")
            {
                return false;
            }
        }
        return true;
    }
    public static Object GetChoice(Dictionary<string, Func<Object>> menuDict, string choice)
    {
        Object outcome = menuDict[choice]();
        return outcome;
    }
    public static Object GetChoice(Dictionary<string, Func<Object, Object>> menuDict, string choice, Object var)
    {
        Object outcome = menuDict[choice](var);
        return outcome;
    }
    public static void DisplayMenu(Dictionary<string, Func<Object>> menuDict)
    {
        int index = 1;
        foreach(string option in menuDict.Keys)
        {
            try
            {
                string displayKey = FindValueEquivalent($"{index}", menuDict);
                Display($"{index}. {displayKey}");
            }catch{}
            
            index += 1;
        }
    }
    public static void DisplayMenu(Dictionary<string, Func<Object, Object>> menuDict)
    {
        int index = 1;
        foreach(string option in menuDict.Keys)
        {
            try
            {
                string displayKey = FindValueEquivalent($"{index}", menuDict);
                Display($"{index}. {displayKey}");
            }catch{}
            
            index += 1;
        }
    }
    public static string EndMenuRun()
    {
        return "~~||~~ END MENU RUN ~~||~~";
    }
    public static string EndMenuRun(Object var)
    {
        return "~~||~~ END MENU RUN ~~||~~";
    }
    public static string FindValueEquivalent(string starter, Dictionary<string, Func<Object>> dict)
    {
        foreach(string key in dict.Keys)
        {
            if(dict[key] == dict[starter] && key != starter)
            {
                return key;
            }
        }
        return null;
    }
    public static string FindValueEquivalent(string starter, Dictionary<string, Func<Object, Object>> dict)
    {
        foreach(string key in dict.Keys)
        {
            if(dict[key] == dict[starter] && key != starter)
            {
                return key;
            }
        }
        return null;
    }
    public static Dictionary<string, Func<Object>> IndexizeDict(List<string> keyList, List<Func<Object>> valueList)
    {
        int index = 1;
        Dictionary<string, Func<Object>> menuDict = new();

        foreach(string option in keyList)
        {
            menuDict[$"{index}"] = valueList[index-1];
            menuDict[keyList[index-1]] = valueList[index-1];

            index += 1;
        }
        return menuDict;
    }
    public static Dictionary<string, Func<Object, Object>> IndexizeDict(List<string> keyList, List<Func<Object, Object>> valueList)
    {
        int index = 1;
        Dictionary<string, Func<Object, Object>> menuDict = new();

        foreach(string option in keyList)
        {
            menuDict[$"{index}"] = valueList[index-1];
            menuDict[keyList[index-1]] = valueList[index-1];

            index += 1;
        }
        return menuDict;
    }
    public static Dictionary<string, Func<Object>> IndexizeDict(Dictionary<string, Func<Object>> menuDict)
    {
        int index = 1;

        foreach(string option in menuDict.Keys)
        {
            menuDict[$"{index}"] = menuDict[option];

            index += 1;
        }
        return menuDict;
    }
    public static Dictionary<string, Func<Object, Object>> IndexizeDict(Dictionary<string, Func<Object, Object>> menuDict)
    {
        int index = 1;

        foreach(string option in menuDict.Keys)
        {
            menuDict[$"{index}"] = menuDict[option];

            index += 1;
        }
        return menuDict;
    }
//
//List Helps
    public static double FindMinimalValue(List<double> sortList)
    {
        double jahMinSpeed = 999999999999999999;
        
        foreach(double jahCompare in sortList)
        {
            if(jahCompare < jahMinSpeed)
            {
                jahMinSpeed = jahCompare;
            }
        }
        return jahMinSpeed;
    }
    public static int FindMinimalValue(List<int> sortList)
    {
        int jahMinSpeed = 999999999;
        
        foreach(int jahCompare in sortList)
        {
            if(jahCompare < jahMinSpeed)
            {
                jahMinSpeed = jahCompare;
            }
        }
        return jahMinSpeed;
    }
    public static double FindMaximumValue(List<double> sortList)
    {
        double jahMaxSpeed = -999999999999999999;
        
        foreach(double jahCompare in sortList)
        {
            if(jahCompare > jahMaxSpeed)
            {
                jahMaxSpeed = jahCompare;
            }
        }
        return jahMaxSpeed;
    }
    public static int FindMaximumValue(List<int> sortList)
    {
        int jahMaxSpeed = -999999999;
        
        foreach(int jahCompare in sortList)
        {
            if(jahCompare > jahMaxSpeed)
            {
                jahMaxSpeed = jahCompare;
            }
        }
        return jahMaxSpeed;
    }
    public static double FindMinimalValue<T>(List<T> sortList, Func<T, double> method)
    {
        double jahMinSpeed = 999999999999999999;
        
        foreach(T jahCompare in sortList)
        {
            if(method(jahCompare) < jahMinSpeed)
            {
                jahMinSpeed = method(jahCompare);
            }
        }
        return jahMinSpeed;
    }
    public static int FindMinimalValue<T>(List<T> sortList, Func<T, int> method)
    {
        int jahMinSpeed = 999999999;
        
        foreach(T jahCompare in sortList)
        {
            if(method(jahCompare) < jahMinSpeed)
            {
                jahMinSpeed = method(jahCompare);
            }
        }
        return jahMinSpeed;
    }
    public static double FindMaximumValue<T>(List<T> sortList, Func<T, double> method)
    {
        double jahMaxSpeed = -999999999999999999;
        
        foreach(T jahCompare in sortList)
        {
            if(method(jahCompare) > jahMaxSpeed)
            {
                jahMaxSpeed = method(jahCompare);
            }
        }
        return jahMaxSpeed;
    }
    public static int FindMaximumValue<T>(List<T> sortList, Func<T, int> method)
    {
        int jahMaxSpeed = -999999999;
        
        foreach(T jahCompare in sortList)
        {
            if(method(jahCompare) > jahMaxSpeed)
            {
                jahMaxSpeed = method(jahCompare);
            }
        }
        return jahMaxSpeed;
    }
    public static List<T> ReorderList<T>(List<T> unorderedList, Func<T, int> orderProcess, double increment=1)
    {
        List<T> newList = new();
        int minValue = FindMinimalValue<T>(unorderedList, var => orderProcess(var));
        int maxValue = FindMaximumValue<T>(unorderedList, var => orderProcess(var));

        for (double i = minValue; i < maxValue+1; i+=increment)
        {
            foreach(T item in unorderedList)
            {
                if(orderProcess(item) == i)
                {
                    newList.Add(item);
                }
            }
        }
        return newList;
    }
    public static List<T> ReorderList<T>(List<T> unorderedList, Func<T, double> orderProcess, double increment=1)
    {
        List<T> newList = new();
        double minValue = FindMinimalValue<T>(unorderedList, var => orderProcess(var));
        double maxValue = FindMaximumValue<T>(unorderedList, var => orderProcess(var));

        for (double i = minValue; i < maxValue; i+=increment)
        {
            foreach(T item in unorderedList)
            {
                if(orderProcess(item) == i)
                {
                    newList.Add(item);
                }
            }
        }
        return newList;
    }

    public static List<List<int>> GetSquareCoordinates(int radius=1, List<int> originPos=null)
    {
        originPos ??= new(){0, 0};

        int x = radius;
        int y = radius;

        int _x = originPos[0];
        int _y = originPos[1];

        List<List<int>> squareCoordinates = new();

        for(int i = -x; i < x+1; i++)
        {
            //Top
            squareCoordinates.Add(new(){_x+i, _y+y});
            //Bottom
            squareCoordinates.Add(new(){_x-i, _y-y});
        }
        for(int i = -y; i < y+1; i++)
        {
            //Right
            squareCoordinates.Add(new(){_x+x, _y+i});
            //Left
            squareCoordinates.Add(new(){_x-x, _y+i});
        }
        squareCoordinates = RemoveListRedundancies(squareCoordinates);
        return squareCoordinates;
    }
    public static List<int> RemoveListRedundancies(List<int> oldList)
    {
        List<int> newList = new();
        foreach(int item in oldList)
        {
            if (!ListContainsItem<int>(item, newList))
            {
                newList.Add(item);
            }
        }
        return newList;
    }
    public static List<List<int>> RemoveListRedundancies(List<List<int>> oldList)
    {
        List<List<int>> newList = new();
        foreach(List<int> item in oldList)
        {
            if (item[0] == 11 && item[1] == 4)
            {
                Display("");
            }
            if (!ListContainsList<int>(item, newList))
            {
                newList.Add(item);
            }
        }
        return newList;
    }
    public static Boolean ListContainsList<T>(List<T> item, List<List<T>> list)
    {
        foreach(List<T> compare in list)
        {
            if(IsIdentical<T>(item, compare))
            {
                return true;
            }
        }
        return false;
    }
    public static Boolean ListContainsItem<T>(T item, List<T> list)
    {
        foreach(T compare in list)
        {
            if (!item.Equals(compare))
            {
                return false;
            }
        }
        if (list.Count == 0)
        {
            return false;
        }
        return true;
    }
    public static Boolean IsIdentical<T>(List<T> compareOne, List<T> compareTwo)
    {
        return compareOne.SequenceEqual<T>(compareTwo);
    }
    public static Boolean IsIdentical<T>(T compareOne, T compareTwo)
    {
        return compareOne.Equals(compareTwo);
    }
    public static List<T> IntegrateLists<T>(List<T> baseList, List<T> additionalList)
    {
        foreach(T item in additionalList)
        {
            baseList.Add(item);
        }
        return baseList;
    }

    // for (int i = 0; i < 10; i++)
    // {
    //     // i increases by 1
    // }
}