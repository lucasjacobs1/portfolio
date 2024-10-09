package individualapplication.logiclayer.complain;

import individualapplication.datalayer.complainrepo.ComplainEntity;
import individualapplication.logiclayer.complain.complainsubject.ComplainSubjectConverter;
import individualapplication.logiclayer.user.UserConverter;
import individualapplication.models.complain.Complain;

public class ComplainConverter {
    private ComplainConverter(){}

    public static Complain convert(ComplainEntity complainEntity){
        return Complain.builder()
                .id(complainEntity.getId())
                .complainerId(UserConverter.convert(complainEntity.getComplainer()))
                .accusedId(UserConverter.convert(complainEntity.getAccused()))
                .context(complainEntity.getContext())
                .subjectId(ComplainSubjectConverter.convert(complainEntity.getComplainSubject()))
                .build();
    }
}
