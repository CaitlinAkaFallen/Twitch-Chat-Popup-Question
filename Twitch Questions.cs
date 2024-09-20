using System;

public class CPHInline
{
    public bool Execute()
    {
        // Get arguments from Streamer.Bot
        CPH.TryGetArg("commandId", out Guid commandId);
        CPH.TryGetArg("rawInput", out string rawInput); // The question asked by the user
        CPH.TryGetArg("user", out string user); // The username of the person asking the question
        CPH.TryGetArg("userProfileImageUrl", out string userProfileImageUrl); // The user's profile image URL

        // Convert commandId to string for comparison
        string commandIdString = commandId.ToString();

        switch (commandIdString)
        {
            case "12345678-abcd-1234-abcd-12345678abcd": // Popup Question Command

                // Prepare the content for the OBS popup
                string popupContent = $"Question from @{user}: {rawInput}";

                // Set the text in OBS using ObsSetGdiText
                CPH.ObsSetGdiText("SceneName", "QuestionTextSource", popupContent, 0);

                // Set the user's profile image in OBS using ObsSetBrowserSource
                CPH.ObsSetBrowserSource("SceneName", "UserProfileImageSource", userProfileImageUrl, 0);

                // Optionally, send a message back to chat acknowledging the question
                CPH.SendMessage($"Thanks for the question, @{user}!");

                break;

            default:
                CPH.SendMessage($"Unknown command: {commandIdString}");
                break;
        }

        return true;
    }
}
