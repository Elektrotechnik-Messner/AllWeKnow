/*
 * Date: 2023-11-28
 * 
 * Code from https://github.com/Moonlight-Panel/Moonlight
 * 
 * LICENSE.md https://github.com/Moonlight-Panel/Moonlight/blob/main/LICENSE.md
 */

namespace AllWeKnow.App.Helpers;

public class PathBuilder
{
    public static string Dir(params string[] parts)
    {
        var res = "";

        foreach (var part in parts)
        {
            res += part + Path.DirectorySeparatorChar;
        }

        return res.Replace(
            $"{Path.DirectorySeparatorChar}{Path.DirectorySeparatorChar}", 
            $"{Path.DirectorySeparatorChar}"
        );
    }
    
    public static string File(params string[] parts)
    {
        var res = "";

        foreach (var part in parts)
        {
            res += part + (part == parts.Last() ? "" : Path.DirectorySeparatorChar);
        }

        return res.Replace(
            $"{Path.DirectorySeparatorChar}{Path.DirectorySeparatorChar}", 
            $"{Path.DirectorySeparatorChar}"
        );
    }
}