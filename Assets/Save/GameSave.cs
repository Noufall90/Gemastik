using System.IO;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public Transform playerTransform;
    public static int currentLevel;


    private void Start()
    {
        LoadAutosave();
        // Kode lain untuk inisialisasi permainan
    }

    private void LoadAutosave()
    {
        string savePath = Application.persistentDataPath + "/autosave.dat";

        if (File.Exists(savePath))
        {
            // Buat sebuah binary formatter
            var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            // Buka file stream
            var fileStream = new FileStream(savePath, FileMode.Open);

            // Deserialisasi data dari file stream
            var savedData = formatter.Deserialize(fileStream) as SaveData;

            // Tutup file stream
            fileStream.Close();

            // Gunakan data yang di-load untuk menginisialisasi objek-objek atau data permainan
            playerTransform.position = savedData.playerPosition;
            currentLevel = savedData.currentLevel;
        }
    }

    private void Autosave()
    {
        // Buat string path untuk menyimpan file autosave
        string savePath = Application.persistentDataPath + "/autosave.dat";

        // Buat sebuah binary formatter
        var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

        // Buat sebuah file stream
        var fileStream = new FileStream(savePath, FileMode.Create);

        // Simpan data yang ingin di-save ke dalam file stream
        var dataToSave = new SaveData();
        // Isi dataToSave dengan data yang ingin di-save
        dataToSave.playerPosition = playerTransform.position;
        dataToSave.currentLevel = currentLevel;

        // Lakukan serialisasi dataToSave menjadi stream
        formatter.Serialize(fileStream, dataToSave);

        // Tutup file stream
        fileStream.Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Autosave();
            Debug.Log("Game autosaved!");
        }
    }
}
