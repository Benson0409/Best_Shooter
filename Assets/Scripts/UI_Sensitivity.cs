using RhythmGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Vehicles.Ball;

public class UI_Sensitivity : MonoBehaviour
{
    VisualElement root;
    RigidbodyFirstPersonController player;

    public Material song1;
    public Material song2;
    public Material song3;
    public Material song4;
    public Material song5;
    public Material song6;

    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject wall5;

    public GameObject dataManager;

    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5;
    public AudioClip audio6;

    public GameObject conductor;

    public NoteSpawner noteSpawner;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        player = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();

        root.Q<Button>("low").clicked += () => 
        {
            Debug.Log("low");
            player.mouseLook.XSensitivity -= 0.1f;
            player.mouseLook.YSensitivity -= 0.1f;
            root.Q<Label>("sen").text = string.Format("{0:N2}", player.mouseLook.XSensitivity);
        };

        root.Q<Button>("up").clicked += () =>
        {
            Debug.Log("up");
            player.mouseLook.XSensitivity += 0.1f;
            player.mouseLook.YSensitivity += 0.1f;
            root.Q<Label>("sen").text = string.Format("{0:N2}", player.mouseLook.XSensitivity);
        };

        root.Q<Button>("rickroll").clicked += () =>
        {
            dataManager.GetComponent<DataManager>().changeFileName("NoteData.txt");
            dataManager.GetComponent<DataManager>().LoadNoteData();
            conductor.GetComponent<AudioSource>().clip = audio1;
            noteSpawner.SpawnAllNotes();
            changeMaterial(song1);
        };
        root.Q<Button>("rushe").clicked += () =>
        {
            dataManager.GetComponent<DataManager>().changeFileName("NoteData2.txt");
            dataManager.GetComponent<DataManager>().LoadNoteData();
            conductor.GetComponent<AudioSource>().clip = audio2;
            noteSpawner.SpawnAllNotes();
            changeMaterial(song2);
        };
        root.Q<Button>("wii").clicked += () =>
        {
            dataManager.GetComponent<DataManager>().changeFileName("NoteData3.txt");
            dataManager.GetComponent<DataManager>().LoadNoteData();
            conductor.GetComponent<AudioSource>().clip = audio3;
            noteSpawner.SpawnAllNotes();
            changeMaterial(song3);
        };
        root.Q<Button>("tfboys").clicked += () =>
        {
            dataManager.GetComponent<DataManager>().changeFileName("NoteData4.txt");
            dataManager.GetComponent<DataManager>().LoadNoteData();
            conductor.GetComponent<AudioSource>().clip = audio4;
            noteSpawner.SpawnAllNotes();
            changeMaterial(song4);
        };
        root.Q<Button>("minecraft").clicked += () =>
        {
            dataManager.GetComponent<DataManager>().changeFileName("NoteData5.txt");
            dataManager.GetComponent<DataManager>().LoadNoteData();
            conductor.GetComponent<AudioSource>().clip = audio5;
            noteSpawner.SpawnAllNotes();
            changeMaterial(song5);
        };
        root.Q<Button>("cat").clicked += () =>
        {
            dataManager.GetComponent<DataManager>().changeFileName("NoteData6.txt");
            dataManager.GetComponent<DataManager>().LoadNoteData();
            conductor.GetComponent<AudioSource>().clip = audio6;
            noteSpawner.SpawnAllNotes();
            changeMaterial(song6);
        };
    }

    private void changeMaterial(Material songMaterial)
    {
        wall1.GetComponent<MeshRenderer>().material = songMaterial;
        wall2.GetComponent<MeshRenderer>().material = songMaterial;
        wall3.GetComponent<MeshRenderer>().material = songMaterial;
        wall4.GetComponent<MeshRenderer>().material = songMaterial;
        wall5.GetComponent<MeshRenderer>().material = songMaterial;
    }
}
