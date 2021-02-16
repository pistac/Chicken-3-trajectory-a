using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

	[SerializeField]
	private float gameOverDelay = 1.0f;

    private bool localGameOver = false;

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			// Check if experiment is over.
			if (!localGameOver && !SharedVariableManager.instance.gameIsOver) {
				localGameOver = true;

				// Commence game over sequence.
				StartCoroutine(GameOverSequence());
			}
		}
	}

	// Waits for a specified time period, then sets the gameIsOver flag.
	IEnumerator GameOverSequence() {
		if (Application.isEditor) {
			TrialManager.instance.VisualizeTrajectory();
		}

		yield return new WaitForSecondsRealtime(gameOverDelay);
		SharedVariableManager.instance.gameIsOver = true;
	}
}
