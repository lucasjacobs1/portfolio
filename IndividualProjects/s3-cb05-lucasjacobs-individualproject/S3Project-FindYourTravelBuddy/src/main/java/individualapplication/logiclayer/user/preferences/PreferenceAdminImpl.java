package individualapplication.logiclayer.user.preferences;

import individualapplication.datalayer.placerepo.PlaceRepository;
import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceEntity;
import individualapplication.datalayer.userrepo.preferencerepo.PreferenceRepository;
import individualapplication.datalayer.userrepo.UserRepository;
import individualapplication.models.user.preferences.CreatePreferenceRequest;
import individualapplication.models.user.preferences.CreatePreferenceResponse;
import individualapplication.models.user.preferences.UpdatePreferenceRequest;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@AllArgsConstructor
public class PreferenceAdminImpl implements PreferenceAdmin {
    private PreferenceRepository preferenceRepository;
    private UserRepository userRepository;
    private PlaceRepository placeRepository;

    private boolean checkPreferenceValidations(CreatePreferenceRequest request) {
        if (request.getMinAge() > request.getMaxAge()) {
            throw new IllegalArgumentException();
        } else if (request.getMinAge() < 18) {
            throw new IllegalArgumentException();
        } else {
            return true;
        }
    }

    @Override
    public CreatePreferenceResponse createPreference(CreatePreferenceRequest request) {
        checkPreferenceValidations(request);
        PreferenceEntity preference = saveNewPreference(request);

        return CreatePreferenceResponse.builder()
                .id(preference.getId())
                .build();


    }

    private PreferenceEntity saveNewPreference(CreatePreferenceRequest request) {
        PreferenceEntity preferenceEntity = PreferenceEntity.builder()
                .minAge(request.getMinAge())
                .maxAge(request.getMaxAge())
                .gender(request.getGender())
                .place(placeRepository.findById(request.getPlaceId()).orElseThrow())
                .build();
        return preferenceRepository.save(preferenceEntity);
    }

    @Override
    public void updatePreferences(UpdatePreferenceRequest request, Long id) {
        if (request.getMinAge() > request.getMaxAge()) {
            throw new IllegalArgumentException();
        } else if (request.getMinAge() < 18) {
            throw new IllegalArgumentException();
        } else {
            Optional<UserEntity> user = userRepository.findById(id);
            request.setId(user.orElseThrow().getPreference().getId());
            updateFields(request, user.orElseThrow());
        }

    }

    private void updateFields(UpdatePreferenceRequest updatePreferenceRequest, UserEntity user) {
        PreferenceEntity preference = preferenceRepository.findById(user.getPreference().getId()).get();
        preference.setGender(updatePreferenceRequest.getGender());
        preference.setMinAge(updatePreferenceRequest.getMinAge());
        preference.setMaxAge(updatePreferenceRequest.getMaxAge());
        preference.setPlace(placeRepository.getReferenceById(updatePreferenceRequest.getPlaceId()));


        preferenceRepository.save(preference);
    }


}
