using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Renderer))]
public class RendererWrapper : MonoBehaviour {

	public MaterialWrapper matwrapper;
	public Renderer renderer;
	public Color[] currentColors;

	void Awake(){ 
		this.renderer = GetComponent<Renderer>();
		matwrapper = new MaterialWrapper(renderer);
		currentColors = new Color[256];
	}

	public void SetColor(string id, Color color){
		SetColor(Shader.PropertyToID(id), color);
	}

	public void SetColor(int id, Color color){
		currentColors[id] = color;
		matwrapper.SetColor(id, color);
	}

	public Color GetColor(string id){
		return GetColor(Shader.PropertyToID(id));
	}

	public Color GetColor(int id){
		return currentColors[id];
	}

	public void Apply(){
		matwrapper.Apply();
	}

}
