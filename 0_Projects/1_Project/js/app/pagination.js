export function setupPagination(prevBtn, nextBtn, onPrev, onNext) {
    prevBtn.addEventListener('click', onPrev);
    nextBtn.addEventListener('click', onNext);
}