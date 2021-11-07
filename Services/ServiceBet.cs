using ApiRouletteMasiv.Contracts;
using ApiRouletteMasiv.Dto;
using ApiRouletteMasiv.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRouletteMasiv.Services
{
    public class ServiceBet
    {
        private IRepositoryWrapper _repoWrapper;
        public ServiceBet(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<string> StartBet(BetParams betParams, string UserId)
        {
            var isNumericValue = Miscellaneous.GeneralMethods.IsNumeric(betParams.BetValue);
            var result = false;
            string status = string.Empty;

            var roulette = await _repoWrapper.Roulette.GetRouletteByIdAsync(betParams.IdRoulette, Miscellaneous.RouletteStatus.Open.ToString());
            if (roulette != null)
            {
                if (betParams.BetAmount > (decimal)Miscellaneous.RouletteAmounts.BetValueMin && betParams.BetAmount <= (decimal)Miscellaneous.RouletteAmounts.BetValueMax)
                {
                    var wallet = await _repoWrapper.Wallet.GetWalletByUserIdAsync(UserId);
                    if (wallet != null)
                    {
                        if (wallet.Total >= betParams.BetAmount)
                        {
                            Bet bet = new Bet();
                            bet.IdRoulette = betParams.IdRoulette;
                            bet.BetAmount = betParams.BetAmount;
                            bet.BetValue = betParams.BetValue;
                            bet.UserId = UserId;
                            bet.Trace = DateTime.UtcNow;
                            if (isNumericValue)
                            {
                                var betValue = Convert.ToInt32(betParams.BetValue);
                                if (betValue >= (int)Miscellaneous.BetConstants.BetAllowMin && betValue <= (int)Miscellaneous.BetConstants.BetAllowMax)
                                    result = true;
                            }
                            else
                            {
                                if (betParams.BetValue.ToLower().Equals(Miscellaneous.BetStatus.Red.ToString().ToLower()) || betParams.BetValue.ToLower().Equals(Miscellaneous.BetStatus.Black.ToString().ToLower()))
                                    result = true;
                                else
                                    result = false;
                            }

                            if (result)
                            {
                                _repoWrapper.Bet.CreateBet(bet);
                                await _repoWrapper.SaveAsync();
                            }
                        }
                    }
                }

                status = Miscellaneous.BetStatus.Error.ToString();
                if (result)
                    status = Miscellaneous.BetStatus.Success.ToString();
            }
            else
                status = $"{Miscellaneous.RouletteStatus.RouletteNotExist.ToString()} or is {Miscellaneous.RouletteStatus.Close.ToString()}";

            return status;
        }
        public async Task<BetResult> CloseBet(int IdRoulette)
        {
            string status = string.Empty;
            BetResult betResult = new BetResult();
            try
            {
                var roulette = await _repoWrapper.Roulette.GetRouletteByIdAsync(IdRoulette, Miscellaneous.RouletteStatus.Open.ToString());
                if (roulette != null)
                {
                    var bets = await _repoWrapper.Bet.GetListBetRouletteIdAsync(IdRoulette);
                    betResult.Bets = new List<BetDto>();
                    var rulette = GenerateRandomNumberRulette();
                    foreach (var item in bets)
                    {
                        var wallet = await _repoWrapper.Wallet.GetWalletByUserIdAsync(item.UserId);
                        var isNumericValue = Miscellaneous.GeneralMethods.IsNumeric(item.BetValue);
                        if (isNumericValue)
                        {
                            var betValue = Convert.ToInt32(item.BetValue);
                            if (betValue.Equals(rulette))
                            {
                                var totalWinner = wallet.Total + (item.BetAmount * 5);
                                item.Status = Miscellaneous.BetStatus.Winner.ToString();
                                item.Balance = totalWinner;
                                wallet.Total = totalWinner;
                            }
                            else
                            {
                                var totalLost = wallet.Total - item.BetAmount;
                                item.Status = Miscellaneous.BetStatus.Loser.ToString();
                                item.Balance = totalLost;
                                wallet.Total = totalLost;
                            }
                        }
                        else
                        {
                            var color = Miscellaneous.BetStatus.Black.ToString();
                            if ((rulette % 2) == 0)
                                color = Miscellaneous.BetStatus.Red.ToString();

                            if (color.Equals(item.BetValue))
                            {
                                var totalWinner = wallet.Total + (item.BetAmount * Convert.ToDecimal(1.8));
                                item.Status = Miscellaneous.BetStatus.Winner.ToString();
                                item.Balance = totalWinner;
                                wallet.Total = totalWinner;
                            }
                            else
                            {
                                var totalLost = wallet.Total - item.BetAmount;
                                item.Status = Miscellaneous.BetStatus.Loser.ToString();
                                item.Balance = totalLost;
                                wallet.Total = totalLost;
                            }
                        }

                        _repoWrapper.Bet.UpdateBet(item);
                        _repoWrapper.Wallet.UpdateWallet(wallet);
                        await _repoWrapper.SaveAsync();

                        BetDto betDto = new BetDto();
                        betDto.Id = item.Id;
                        betDto.IdRoulette = item.IdRoulette;
                        betDto.BetAmount = item.BetAmount;
                        betDto.BetValue = item.BetValue;
                        betDto.Trace = item.Trace;
                        betDto.Status = item.Status;
                        betResult.Bets.Add(betDto);
                    }

                    roulette.Status = Miscellaneous.RouletteStatus.Close.ToString();
                    roulette.CloseAt = DateTime.UtcNow;
                    _repoWrapper.Roulette.UpdateRoulette(roulette);
                    await _repoWrapper.SaveAsync();
                    status = Miscellaneous.BetStatus.Success.ToString();
                }
                else
                    status = $"{Miscellaneous.RouletteStatus.RouletteNotExist.ToString()} or is {Miscellaneous.RouletteStatus.Close.ToString()}";
            }
            catch (Exception ex)
            {
                status = Miscellaneous.BetStatus.Error.ToString();
            }

            betResult.Status = status;
            return betResult;
        }
        private int GenerateRandomNumberRulette()
        {
            Random generator = new Random();
            return generator.Next((int)Miscellaneous.BetConstants.BetAllowMin, (int)Miscellaneous.BetConstants.BetAllowMax);
        }
    }
}