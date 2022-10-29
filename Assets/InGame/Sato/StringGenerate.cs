using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 穴掘り法を用いてステージ生成用の文字列を作成する
/// </summary>
public class StringGenerate : MonoBehaviour
{
    enum Direction
    {
        Up, Down, Left, Right,
    }

    // スタート候補のマスとゴール候補のマス
    List<(int, int)> _startMasses = new List<(int, int)>();
    List<(int, int)> _goalMasses = new List<(int, int)>();

    readonly string Road = "O";
    readonly string Wall = "W";
    readonly string Exit = "E";
    readonly string Start = "S";

    /// <summary>ステージ用の文字列を生成する</summary>
    public string Generate(int height, int width)
    {
        if (width % 2 == 0 && height % 2 == 0)
        {
            Debug.LogError("ステージの高さと幅は奇数で指定してください");
            return null;
        }

        string[,] map = new string[height, width];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                map[i, j] = i * j == 0 || i == height - 1 || j == width - 1 ? Road : Wall;

        _startMasses.Add((1, 1));
        _goalMasses.Add((1, 1));

        DiggingPass(map, _startMasses);

        for (int i = 0; i < map.GetLength(0); i++)
        {
            map[i, 0] = Wall;
            map[i, map.GetLength(1) - 1] = Wall;
        }
        for (int i = 0; i < map.GetLength(1); i++)
        {
            map[0, i] = Wall;
            map[map.GetLength(0) - 1, i] = Wall;
        }

        SetSpotRandom(map, Exit);
        SetSpotRandom(map, Start);

        return ArrayToString(map);
    }

    /// <summary>穴を掘る</summary>
    void DiggingPass(string[,] map, List<(int, int)> startMasses)
    {
        int startIndex = Random.Range(0, startMasses.Count);
        int x = startMasses[startIndex].Item1;
        int y = startMasses[startIndex].Item2;

        startMasses.RemoveAt(startIndex);

        while (true)
        {
            List<Direction> dirs = new List<Direction>();

            if (map[x, y - 1] == Wall && map[x, y - 2] == Wall)
                dirs.Add(Direction.Up);
            if (map[x, y + 1] == Wall && map[x, y + 2] == Wall)
                dirs.Add(Direction.Down);
            if (map[x - 1, y] == Wall && map[x - 2, y] == Wall)
                dirs.Add(Direction.Left);
            if (map[x + 1, y] == Wall && map[x + 2, y] == Wall)
                dirs.Add(Direction.Right);

            if (dirs.Count == 0) break;

            map[x, y] = Road;

            int dirIndex = Random.Range(0, dirs.Count);
            switch (dirs[dirIndex])
            {
                case Direction.Up:
                    DiggingMass(map, x, --y);
                    DiggingMass(map, x, --y);
                    break;
                case Direction.Down:
                    DiggingMass(map, x, ++y);
                    DiggingMass(map, x, ++y);
                    break;
                case Direction.Left:
                    DiggingMass(map, --x, y);
                    DiggingMass(map, --x, y);
                    break;
                case Direction.Right:
                    DiggingMass(map, ++x, y);
                    DiggingMass(map, ++x, y);
                    break;
            }
        }

        _goalMasses.Add((x, y));

        if (startMasses.Count > 0)
            DiggingPass(map, startMasses);
    }

    /// <summary>渡されたマスを掘る</summary>
    void DiggingMass(string[,] map, int x, int y)
    {
        map[x, y] = Road;
        // そのマスが奇数の場合はスタートの候補としてリストに登録する
        if (x * y % 2 != 0)
            _startMasses.Add((x, y));
    }

    /// <summary>マップの行き止まりを探して置換する</summary>
    void SetSpotRandom(string[,] map, string word)
    {
        foreach ((int, int) mass in _goalMasses
            .OrderBy(r => System.Guid.NewGuid())
            .Where(i => map[i.Item1, i.Item2] == Road))
        {
            // 3方向が壁かどうか調べるが、必要ないとわかったら処理を省く
            int count = 0;
            if (map[mass.Item1 - 1, mass.Item2] == Wall) count++;
            if (map[mass.Item1 + 1, mass.Item2] == Wall) count++;
            if (map[mass.Item1, mass.Item2 - 1] == Wall) count++;
            if (map[mass.Item1, mass.Item2 + 1] == Wall) count++;

            if (count == 3)
            {
                map[mass.Item1, mass.Item2] = word;
                break;
            }
        }
    }

    /// <summary>二次元配列を文字列にして返す</summary>
    protected string ArrayToString(string[,] array)
    {
        string str = "";
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
                str += array[i, j];
            if (i < array.GetLength(0) - 1)
                str += '\n';
        }
        //Debug.Log(str); // デバッグ用に残しておく
        return str;
    }
}