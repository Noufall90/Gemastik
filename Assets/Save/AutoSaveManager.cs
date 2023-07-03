using System.IO;
using UnityEngine;

public class AutosaveManager : MonoBehaviour
{
    public Transform playerTransform;

    private void Start()
    {
        // Panggil fungsi Autosave saat permainan dimulai
        Autosave();
    }

    public void Autosave()
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
        dataToSave.currentLevel = GameSave.currentLevel;

        // Lakukan serialisasi dataToSave menjadi stream
        formatter.Serialize(fileStream, dataToSave);

        // Tutup file stream
        fileStream.Close();
    }
}
