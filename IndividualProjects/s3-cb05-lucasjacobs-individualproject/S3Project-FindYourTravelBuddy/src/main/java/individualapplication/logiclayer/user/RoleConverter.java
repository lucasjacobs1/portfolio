package individualapplication.logiclayer.user;

import individualapplication.datalayer.userrepo.roleentity.RoleEntity;
import individualapplication.models.user.UserRole;

public final class RoleConverter {
    private RoleConverter(){}

    public static UserRole convert(RoleEntity entity){
        return UserRole.builder()
                .id(entity.getId())
                .name(entity.getName())
                .user(entity.getUser().getId())
                .build();
    }
}
