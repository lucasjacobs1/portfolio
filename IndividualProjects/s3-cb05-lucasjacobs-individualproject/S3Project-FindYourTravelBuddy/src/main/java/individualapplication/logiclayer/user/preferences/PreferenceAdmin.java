package individualapplication.logiclayer.user.preferences;

import individualapplication.models.user.preferences.CreatePreferenceRequest;
import individualapplication.models.user.preferences.CreatePreferenceResponse;
import individualapplication.models.user.preferences.UpdatePreferenceRequest;

public interface PreferenceAdmin {
    CreatePreferenceResponse createPreference(CreatePreferenceRequest request);

    void updatePreferences(UpdatePreferenceRequest request, Long id);}
