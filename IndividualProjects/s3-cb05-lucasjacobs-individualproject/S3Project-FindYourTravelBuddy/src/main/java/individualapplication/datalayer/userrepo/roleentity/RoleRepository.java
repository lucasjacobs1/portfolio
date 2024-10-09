package individualapplication.datalayer.userrepo.roleentity;

import org.springframework.data.jpa.repository.JpaRepository;

public interface RoleRepository extends JpaRepository<RoleEntity, Long> {
    RoleEntity getRoleEntityByUserId(Long id);
}
