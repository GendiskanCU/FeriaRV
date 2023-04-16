using System.Collections;
using System.Collections.Generic;
using System;

namespace FeriaVirtual{
    public interface FeriaVirtualDataProvider{
        public List<UIStrings> GetUIStrings();
    }
}
