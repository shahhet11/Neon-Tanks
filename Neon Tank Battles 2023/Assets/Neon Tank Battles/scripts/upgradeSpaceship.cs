using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradeSpaceship : MonoBehaviour {

	public Text numberOfStars;

	public Text healthLevel;
	public Text spacecraftSpeedLevel;
	public Text damageLevel;
	public Text fireSpeedLevel;

	public Text healthPrice;
	public Text spacecraftSpeedPrice;
	public Text damagePrice;
	public Text fireSpeedPrice;

	int health = 0;
	int spacecraftSpeed = 0;
	int damage = 0;
	int fireSpeed = 0;

	public void refresh() {
		numberOfStars.text = ""+(int)(PlayerPrefs.GetInt("collectedStars") - PlayerPrefs.GetInt("spentStars"));

		health = (int)(((PlayerPrefs.GetInt("healthLevel")+1) * 10) * ((1.5f + PlayerPrefs.GetInt("healthLevel")) / 2));
		spacecraftSpeed = (int)(((PlayerPrefs.GetInt("spacecraftSpeedLevel")+1) * 5) * ((1.5f + PlayerPrefs.GetInt("spacecraftSpeedLevel")) / 2));
		damage = (int)(((PlayerPrefs.GetInt("damageLevel")+1) * 10) * ((1.3f + PlayerPrefs.GetInt("damageLevel"))/2));
		fireSpeed = (int)(((PlayerPrefs.GetInt("fireSpeedLevel") +1) * 10) * ((1.7f + PlayerPrefs.GetInt("fireSpeedLevel")) / 2));

		healthPrice.text = "" + health;
		spacecraftSpeedPrice.text = "" + spacecraftSpeed;
		damagePrice.text = "" + damage;
		fireSpeedPrice.text = "" + fireSpeed;

		healthLevel.text = "" + PlayerPrefs.GetInt("healthLevel") +"/50";
		spacecraftSpeedLevel.text = "" + PlayerPrefs.GetInt("spacecraftSpeedLevel") +"/50";
		damageLevel.text = "" + PlayerPrefs.GetInt("damageLevel") +"/50";
		fireSpeedLevel.text = "" + PlayerPrefs.GetInt("fireSpeedLevel") +"/50";


	}
		

	public void upgradeHealth() {
		if(PlayerPrefs.GetInt("healthLevel") < 50) {
			if ((PlayerPrefs.GetInt ("collectedStars") - PlayerPrefs.GetInt ("spentStars")) >= health) {
				PlayerPrefs.SetInt ("healthLevel", PlayerPrefs.GetInt ("healthLevel") + 1);
				PlayerPrefs.SetInt ("spentStars", PlayerPrefs.GetInt ("spentStars") + health);
				refresh ();
			}
		}
	}
	public void upgradeSpacecraftSpeed() {
		if (PlayerPrefs.GetInt ("spacecraftSpeedLevel") < 50) {
			if ((PlayerPrefs.GetInt ("collectedStars") - PlayerPrefs.GetInt ("spentStars")) >= spacecraftSpeed) {
				PlayerPrefs.SetInt ("spacecraftSpeedLevel", PlayerPrefs.GetInt ("spacecraftSpeedLevel") + 1);
				PlayerPrefs.SetInt ("spentStars", PlayerPrefs.GetInt ("spentStars") + spacecraftSpeed);
				refresh ();
			}
		}
	}
	public void upgradeDamage(){
		if (PlayerPrefs.GetInt ("damageLevel") < 50) {
			if ((PlayerPrefs.GetInt ("collectedStars") - PlayerPrefs.GetInt ("spentStars")) >= damage) {
				PlayerPrefs.SetInt ("damageLevel", PlayerPrefs.GetInt ("damageLevel") + 1);
				PlayerPrefs.SetInt ("spentStars", PlayerPrefs.GetInt ("spentStars") + damage);
				refresh ();
			}
		}
	}
	public void upgradeFireSpeed() {
		if (PlayerPrefs.GetInt ("fireSpeedLevel") < 50) {
			if ((PlayerPrefs.GetInt ("collectedStars") - PlayerPrefs.GetInt ("spentStars")) >= fireSpeed) {
				PlayerPrefs.SetInt ("fireSpeedLevel", PlayerPrefs.GetInt ("fireSpeedLevel") + 1);
				PlayerPrefs.SetInt ("spentStars", PlayerPrefs.GetInt ("spentStars") + fireSpeed);
				refresh ();
			}
		}
	}
}
