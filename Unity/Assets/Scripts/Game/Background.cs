using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lp2EpocaEspecial.Common;
/// <summary>
/// Contains the map of the game.
/// Also setups the map of the game
/// </summary>
public class Background : MonoBehaviour
{
    public Map gameMap { get; set; }
    public List<GameObject> ObjectsList;
    public void Awake()
    {
        gameMap = SetupMap();
    }
    public Map SetupMap()
    {
        Vertex vertex1 = new Vertex('1', Value.Black);
        Vertex vertex2 = new Vertex('9', Value.OutofGame);
        Vertex vertex3 = new Vertex('2', Value.White);
        Vertex vertex4 = new Vertex('3', Value.White);
        Vertex vertex5 = new Vertex('8', Value.None);
        Vertex vertex6 = new Vertex('4', Value.Black);
        Vertex vertex7 = new Vertex('5', Value.Black);
        Vertex vertex8 = new Vertex('9', Value.Connection);
        Vertex vertex9 = new Vertex('6', Value.White);
        List<Point> points = new List<Point>();
        Point point1 = new Point('1', vertex1);
        Point point2 = new Point('2', vertex3);
        Point point3 = new Point('3', vertex4);
        Point point4 = new Point('4', vertex5);
        Point point5 = new Point('5', vertex6);
        Point point6 = new Point('6', vertex7);
        Point point7 = new Point('7', vertex9);
        Point point8 = new Point('8', vertex2);
        Point point9 = new Point('9', vertex8);
        points.Add(point1);
        points.Add(point8);
        points.Add(point2);
        points.Add(point3);
        points.Add(point4);
        points.Add(point5);
        points.Add(point6);
        points.Add(point9);
        points.Add(point7);
        point1.connections.Add(point3);
        point1.connections.Add(point4);
        point2.connections.Add(point5);
        point2.connections.Add(point4);
        point3.connections.Add(point1);
        point3.connections.Add(point4);
        point3.connections.Add(point6);
        point4.connections.Add(point1);
        point4.connections.Add(point2);
        point4.connections.Add(point3);
        point4.connections.Add(point5);
        point4.connections.Add(point6);
        point4.connections.Add(point7);
        point5.connections.Add(point2);
        point5.connections.Add(point4);
        point5.connections.Add(point7);
        point6.connections.Add(point3);
        point6.connections.Add(point4);
        point6.connections.Add(point7);
        point7.connections.Add(point4);
        point7.connections.Add(point5);
        point7.connections.Add(point6);
        gameMap = new Map(points);
        return gameMap;
    }
}
