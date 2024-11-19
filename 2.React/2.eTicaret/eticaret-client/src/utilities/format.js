export const formatCurrency = (amount) => {
	return new Intl.NumberFormat("tr-TR", {
	  style: "currency",
	  currency: "TRY",
	  minimumFractionDigits: 2,
	}).format(amount);
  };