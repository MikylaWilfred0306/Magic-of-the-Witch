using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Movie : MonoBehaviour {
	public VideoPlayer Intro_Movie;
	void Start()
	{
		Intro_Movie.Play();
		StartCoroutine("waitForMovieEnd");
	} 



	IEnumerator waitForMovieEnd()
	{

		while(Intro_Movie.isPlaying) // while the movie is playing
		{
			yield return new WaitForEndOfFrame();

		}
		// after movie is not playing / has stopped.
		onMovieEnded();
	}

	void onMovieEnded()
	{
		Debug.Log("Movie Ended!");
		Application.LoadLevel("MainWorld");
	}
}
