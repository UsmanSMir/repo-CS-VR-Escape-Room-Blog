using UnityEngine;
public class KeyPad : MonoBehaviour
{
    private static string correctCode = "719"; //Customize to your code and align with the clue in the scene
    private static string currentEntry = ""; //Tracks what we have been inputting

    public string thisKey = ""; //A value you can assign in the inspector to match the model

    public AudioSource audioSource; //The KeyPad AudioSource to play sounds
    public AudioClip ketHit; //The sound played on every touch of a key
    public AudioClip successSound; //Correct Pin entered
    public AudioClip errorSound; //Resetting the pin error sound

    private void OnTriggerEnter(Collider other) //If a Key is touched
    {
        if (other.CompareTag("Player")) //If the player was what touched the key
        {
            currentEntry += thisKey; //Add this key's value to our curret Entry
            if (currentEntry.Length > 2) //If our entry is more than 2 characters
            {
                if (currentEntry == correctCode) //If our entry matches the correct Code
                {
                    GetComponentInParent<Animator>().SetTrigger("Unlock"); //Animat Door Opening
                    audioSource.PlayOneShot(successSound); //Play the success Sound on our keypad
                    currentEntry = ""; //Reset current Entry to nothing
                }
                else //If we didn't enter the right code
                {
                    currentEntry = ""; //Reset current Entry to nothing
                    audioSource.PlayOneShot(errorSound); //Play Error Sound
                }
            }
            else //Our current Entry is not more than 2 characters in length
            {
                audioSource.PlayOneShot(ketHit); //Play the key pressed sound
            }
        }
    }
}
