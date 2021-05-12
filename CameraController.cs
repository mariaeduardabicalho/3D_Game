using UnityEngine;
 using System.Collections;
 
 public class CameraController: MonoBehaviour {
//  public float waterHeight;
 
//  private bool isUnderwater;
//  private Color normalColor;
 private Color underwaterColor;
 
 // Use this for initialization
 void Start () {
 
 underwaterColor = new Color (0.22f, 0.65f, 0.77f, 0.5f);
 RenderSettings.fogColor = underwaterColor;
 RenderSettings.fogDensity = 0.1f;

 }
 
 }