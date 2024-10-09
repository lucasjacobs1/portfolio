package individualapplication.logiclayer.user.preferences;

import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.logiclayer.places.PlaceConverter;
import individualapplication.models.user.preferences.Preference;

public class PreferenceConverter {
    private PreferenceConverter(){

    }

    public static Preference convert(PreferenceEntity preferenceEntity){
        return Preference.builder()
                .id(preferenceEntity.getId())
                .minAge(preferenceEntity.getMinAge())
                .maxAge(preferenceEntity.getMaxAge())
                .place(PlaceConverter.convert(preferenceEntity.getPlace()))
                .gender(preferenceEntity.getGender())
                .build();
    }
}
