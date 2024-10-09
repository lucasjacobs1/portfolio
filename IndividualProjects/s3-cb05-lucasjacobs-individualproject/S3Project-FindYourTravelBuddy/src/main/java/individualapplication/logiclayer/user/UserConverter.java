package individualapplication.logiclayer.user;

import individualapplication.datalayer.userrepo.UserEntity;
import individualapplication.logiclayer.user.algochoice.AlgoChoiceConverter;
import individualapplication.logiclayer.user.preferences.PreferenceConverter;
import individualapplication.models.user.User;

//it was final now public look if this breaking any rules
public final class UserConverter {
    private UserConverter(){

    }

    public static User convert(UserEntity userEntity){
        return User.builder()
                .id(userEntity.getId())
                .firstName(userEntity.getFirstName())
                .lastName(userEntity.getLastName())
                .userName(userEntity.getUserName())
                .email(userEntity.getEmail())
                .gender(userEntity.getGender())
                .birthday(userEntity.getBirthday())
                .password(userEntity.getPassword())
                //.roles(RoleConverter.convert(userEntity.getUserRoles()))
                .preference(PreferenceConverter.convert(userEntity.getPreference()))
                .algoChoice(AlgoChoiceConverter.convert(userEntity.getBuddyMatchAlgo()))
                .build();
    }
}
