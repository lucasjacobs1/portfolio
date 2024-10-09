package individualapplication.logiclayer.complain.complainsubject;

import individualapplication.datalayer.complainrepo.complainsubject.ComplainSubjectEntity;
import individualapplication.models.complain.complainsubject.ComplainSubject;

public class ComplainSubjectConverter {
    private ComplainSubjectConverter(){}

    public static ComplainSubject convert(ComplainSubjectEntity complainEntity){
        return ComplainSubject.builder()
                .id(complainEntity.getId())
                .name(complainEntity.getName())
                .build();
    }
}
