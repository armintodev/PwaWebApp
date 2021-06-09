const RetrySendSMSBox = document.querySelector(".retry__send__sms");
window.addEventListener("DOMContentLoaded", () => {
  Counter();
});

function Counter() {
  const CountDownElement = document.querySelector("[data-count-num]");
  let CounterNumber = Number(CountDownElement.dataset.countNum) - 1;
  setInterval(() => {
    if (CounterNumber >= 0) {
      CountDownElement.textContent = CounterNumber;
      CounterNumber -= 1;
    } else {
      RetrySendSMSBox.classList.remove("d-none");
    }
  }, 1000);
}
