namespace NurBNB.Reservas.SharedKernel.Core;

public interface IBussinessRule
{
    bool IsValid();

    string Message { get; }
}
