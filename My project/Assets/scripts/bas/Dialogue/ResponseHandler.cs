using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;


// responseHandler zorgt ervoor dat je op een response button kan klikken en er een antwoord op komt.

public class ResponseHandler : MonoBehaviour
{
    //link aan de ui
    public RectTransform responseBox;
    public RectTransform responseButtonTemplate;
    public RectTransform responseContainer;

    private DialogeuUI dialogueUI;

    List<GameObject> tempResponseButtons = new List<GameObject>();//maakt een lijst voor de response buttons

    private void Start()
    {
        dialogueUI = GetComponent<DialogeuUI>();
    }

    public void ShowResponses(Response[] responses)
    {
        float responseBoxHeight = 0;//bepaalt de responsebox hoogte

        for (int i = 0; i < responses.Length; i++)
        {
            Response response = responses[i];
            int responseIndex = i;

            GameObject responseButton = Instantiate(responseButtonTemplate.gameObject, responseContainer);//spawnt de response button in de responseContainer
            responseButton.gameObject.SetActive(true);//zet de responsebutton aan
            responseButton.GetComponent<TMP_Text>().text = response.ResponseText;//zet de text van de knop naar de text in response text
            responseButton.GetComponent<Button>().onClick.AddListener(call: () => OnPickedResponse(response));//plaatst een reactie op de knop en geeft de response die is gekozen door.

            tempResponseButtons.Add(responseButton);//voegt de buttons toe die zijn aangemaakt aan de lijst tempresponsebutton


            responseBoxHeight += responseButtonTemplate.sizeDelta.y;//maakt de response box hoogte het zelfde als de template
        }

        responseBox.sizeDelta = new Vector2(responseBox.sizeDelta.x, y: responseBoxHeight);//maakt de responsebox groote het zelfde als de hoogte van de template en de breete van de template
        responseBox.gameObject.SetActive(true);//zet responsebox aan
    }

    public void OnPickedResponse(Response response)
    {
        responseBox.gameObject.SetActive(false);

        foreach (GameObject button in tempResponseButtons)//verwijdert elke button nadat er op 1 is geklikt
        {
            Destroy(button);
        }
        tempResponseButtons.Clear();//cleared de lijst

        if (response.hasEvent == true)
        {
            Instantiate(response.reaction, response.activatorLoc, Quaternion.identity);
        }

        dialogueUI.ShowDialogue(response.DialogueObject); //maakt de dialogue opject in dialogue UI de dialogue object die in response staat
    }
}
