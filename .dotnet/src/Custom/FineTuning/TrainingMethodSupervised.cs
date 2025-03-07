using OpenAI.FineTuning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.FineTuning;

[CodeGenType("FineTuneSupervisedMethodHyperparameters")]
public partial class HyperparametersForSupervised : MethodHyperparameters
{
    [CodeGenMember("BatchSize")]
    internal BinaryData _BatchSize { get; set; }

    [CodeGenMember("NEpochs")]
    internal BinaryData _NEpochs { get; set; }

    [CodeGenMember("LearningRateMultiplier")]
    internal BinaryData _LearningRateMultiplier { get; set; }
    public int BatchSize => (int)HandleDefaults(_BatchSize);
    public int EpochCount => (int)HandleDefaults(_NEpochs);
    public float LearningRateMultiplier => HandleDefaults(_LearningRateMultiplier);

}
