using System;

public class CPHInline
{
    public bool Execute()
    {
        // Get arguments from Streamer.Bot (case-sensitive)
        CPH.TryGetArg("message", out string message); 
        CPH.TryGetArg("user", out string user);
        CPH.TryGetArg("targetUserProfileImageUrl", out string targetUserProfileImageUrl); 

        // Debug: check if the URL is valid
        Console.WriteLine($"Profile Image URL: {targetUserProfileImageUrl}");

        // Prepare the content for the OBS popup
        string popupContent = $"Question from @{user}: {message}";

        // Set the text in OBS using ObsSetGdiText
        // Replace "QuestionTextSource" with the actual name of your GDI text source
        CPH.ObsSetGdiText("Twitch Chat Question", "QuestionTextSource", popupContent, 0);

        // Set the user's profile image in OBS using ObsSetBrowserSource
        if (!string.IsNullOrEmpty(targetUserProfileImageUrl))
        {
            // The second parameter "Twitch image" must match the name of your browser source in OBS
            CPH.ObsSetBrowserSource("Twitch Chat Question", "Twitch image", targetUserProfileImageUrl, 0);
        }

        return true;
    }
}

