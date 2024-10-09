package individualapplication.logiclayer.complain;

import individualapplication.models.complain.CreateComplainRequest;
import individualapplication.models.complain.CreateComplainResponse;
import individualapplication.models.complain.GetComplainsResponse;

public interface ComplainAdmin {
    CreateComplainResponse createComplain(CreateComplainRequest request);
    GetComplainsResponse getComplains();
}
