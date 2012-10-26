using ModulusChecking.Loaders;
using ModulusChecking.Models;

namespace ModulusChecking.Steps
{
    interface IStep
    {
        bool Process(BankAccountDetails bankAccountDetails, IModulusWeightTable modulusWeightTable);
    }
}